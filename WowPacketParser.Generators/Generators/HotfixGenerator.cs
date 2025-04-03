using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using WowPacketParser.Generators.Extensions;
using WowPacketParser.Generators.Templates;
using WowPacketParser.Shared.Attributes;
using Type = WowPacketParser.Generators.MetaModel.Type;

namespace WowPacketParser.Generators.Generators
{
    using BackedProperty = (IPropertySymbol Property, IFieldSymbol Field);

    [Generator]
    public class HotfixGenerator : IIncrementalGenerator
    {
        private static readonly DiagnosticDescriptor NoEligibleConstructor = new(
            id: "HG001",
            title: "Cannot emit a parsing constructor",
            messageFormat: "The type '{0}' is annotated with [HotfixTable] but does not have exactly one partial constructor",
            category: "WowPacketParser",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Find all types annotated with [HotfixTable].
            var hotfixTables = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: static (syntaxNode, _) => syntaxNode is TypeDeclarationSyntax,
                transform: static (context, cts) => Transform((TypeDeclarationSyntax) context.Node, context.SemanticModel, cts)
            ).Where(x => x is not null);

            context.RegisterSourceOutput(hotfixTables, static (spc, maybeModel) => {
                var (model, errorType) = maybeModel!;
                
                if (errorType != null)
                {
                    foreach (var location in errorType.Locations)
                        spc.ReportDiagnostic(Diagnostic.Create(NoEligibleConstructor, location, errorType.Name));
                }
                else
                {
                    spc.AddSource($"{model!.Name}.g.cs", model.Render());
                }
            });
        }

        private static Either<HotfixType, ITypeSymbol>? Transform(TypeDeclarationSyntax node, SemanticModel semanticModel, CancellationToken cts)
        {
            // Bail if type symbol not found.
            if (semanticModel.GetDeclaredSymbol(node, cts) is not ITypeSymbol typeSymbol)
                return null;

            // Only process types annotated with [HotfixTable<T>(Hash = ...)].
            var hotfixTable = typeSymbol.FindAttribute(
                static attr => attr.AttributeClass?.OriginalDefinition.GetFullyQualifiedName() == typeof(HotfixTableAttribute<>).FullName);

            if (hotfixTable is null)
                return null;
       
            // Find all partial constructors.
            // We don't filter types that don't have exactly one partial constructor here
            // because we want to emit diagnostics for those types.
            var candidateConstructor = typeSymbol.GetMembers()
                .Where(x => x.Kind == SymbolKind.Method)
                .Cast<IMethodSymbol>()
                .Where(x => x.MethodKind == MethodKind.Constructor && x.IsPartialDefinition)
                .SingleOrDefault();

            if (candidateConstructor == null)
                return new (null, typeSymbol);

            // Collect all auto-generated properties, these are of interest to us.
            var properties = typeSymbol.GetMembers()
                .Where(x => x.Kind == SymbolKind.Property)
                .Cast<IPropertySymbol>()
                .Select(x => (Property: x, Field: x.GetBackingField()))
                .Where(tpl => tpl.Field != null);

            return MakeModel(typeSymbol, candidateConstructor, properties);
        }
        
        internal static Either<HotfixType, ITypeSymbol> MakeModel(ITypeSymbol type, IMethodSymbol constructor, IEnumerable<BackedProperty> members)
        {
            var properties = members.Select(static backedProperty =>
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

            return new (new(type, properties), null);
        }
    }

}
