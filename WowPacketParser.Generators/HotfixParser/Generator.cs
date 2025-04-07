using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading;

using WowPacketParser.Generators.Actions;
using WowPacketParser.Generators.Definitions;
using WowPacketParser.Generators.Extensions;
using WowPacketParser.Shared.Attributes;

namespace WowPacketParser.Generators.HotfixParser
{
    using BackedProperty = (IPropertySymbol Property, IFieldSymbol Field);

    [Generator]
    public class Generator : IIncrementalGenerator
    {
        private static readonly DiagnosticDescriptor NoEligibleConstructor = new(
            id: "HG001",
            title: "Cannot emit a parsing constructor",
            messageFormat: "The type '{0}' is annotated with [HotfixTable] but does not have exactly one partial constructor",
            category: "WowPacketParser",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        private static readonly DiagnosticDescriptor PropertyIgnored = new(
            id: "HG002",
            title: "Property can't be deserialized",
            messageFormat: "This property can't be part of deserialization because the backing field could not be found",
            category: "WowPacketParser",
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true);

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var definitions = context.MetadataReferencesProvider.SelectMany(static (metadataReference, cts) =>
            {
                if (metadataReference is PortableExecutableReference peReference
                    && peReference.GetMetadata() is AssemblyMetadata metadata)
                {
                    return metadata.GetModules()
                        .SelectMany(module =>
                        {
                            var metadataReader = module.GetMetadataReader();
                            return metadataReader.ManifestResources
                                .Select(metadataReader.GetManifestResource)
                                .Where(resource => metadataReader.GetString(resource.Name).EndsWith(".dbd"))
                                .Where(resource => resource.Implementation.Kind == HandleKind.AssemblyFile)
                                .Select(resource =>
                                {
                                    var hashValue = metadataReader.GetAssemblyFile((AssemblyFileHandle) resource.Implementation).HashValue;
                                    return metadataReader.GetBlobReader(hashValue);
                                })
                                .Select(ClientDatabaseDefinition.ParseBinary);
                        });
                }

                return [];
            });

            var hotfixTables = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: static (syntaxNode, _) => syntaxNode is TypeDeclarationSyntax,
                transform: static (context, cts) => Transform((TypeDeclarationSyntax) context.Node, context.SemanticModel, cts)
            ).Where(x => x is not null);

            context.RegisterSourceOutput(hotfixTables, static (spc, action) => action.Run(spc));
        }

        private static IProductionAction Transform(TypeDeclarationSyntax node, SemanticModel semanticModel, CancellationToken cts)
        {
            // Bail if type symbol not found.
            if (semanticModel.GetDeclaredSymbol(node, cts) is not ITypeSymbol typeSymbol)
                return EmptyProductionAction.Instance;

            // Only process types annotated with [HotfixTable<T>(Hash = ...)].
            var hotfixTable = typeSymbol.FindAttribute(
                static attr => attr.AttributeClass?.OriginalDefinition.GetFullyQualifiedName() == typeof(HotfixTableAttribute<>).FullName);

            if (hotfixTable is null)
                return EmptyProductionAction.Instance;

            // Find all partial constructors.
            // We don't filter types that don't have exactly one partial constructor here
            // because we want to emit diagnostics for those types.
            var candidateConstructor = typeSymbol.GetMembers()
                .Where(x => x.Kind == SymbolKind.Method)
                .Cast<IMethodSymbol>()
                .Where(x => x.MethodKind == MethodKind.Constructor && x.IsPartialDefinition)
                .SingleOrDefault();

            // Collect all auto-generated properties, these are of interest to us.
            var properties = typeSymbol.GetMembers()
                .Where(x => x.Kind == SymbolKind.Property)
                .Cast<IPropertySymbol>()
                .Select(x => (Property: x, Field: x.GetBackingField()));

            return MakeModel(typeSymbol, candidateConstructor, properties);
        }
        
        internal static IProductionAction MakeModel(ITypeSymbol type, IMethodSymbol? constructor, IEnumerable<BackedProperty> members)
        {
            if (constructor == null)
                return DiagnosticProductionAction.Create(NoEligibleConstructor, type.Locations, type.Name);

            var ineligibleProperties = members
                .Where(member => member.Field is null)
                .Select(static property => DiagnosticProductionAction.Create(PropertyIgnored, property.Property.Locations, property.Property.Name))
                .ToProductionAction();

            var eligibleProperties = members
                .Where(member => member.Field is not null)
                .Select(static backedProperty =>
                {
                    var (property, field) = backedProperty;

                    // Collect metadata about the property
                    var addedInVersion = property.FindAttribute<AddedInVersionAttribute>()
                        ?.FindArgument(nameof(AddedInVersionAttribute.Version))
                        ?.ToEnumeration();
                    var removedInVersion = property.FindAttribute<RemovedInVersionAttribute>()
                        ?.FindArgument(nameof(RemovedInVersionAttribute.Version))
                        ?.ToEnumeration();

                    return new HotfixProperty(property, field, property.Type, addedInVersion, removedInVersion);
                });

            var template = new Template(type, eligibleProperties, constructor);
            var templateAction = new TemplateProductionAction<Template>($"{type.Name}.Parser.g.cs", template);

            return ineligibleProperties.And(templateAction);
        }
    }

}
