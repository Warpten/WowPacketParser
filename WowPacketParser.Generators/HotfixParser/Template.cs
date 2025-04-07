using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.CodeAnalysis;

using WowPacketParser.Generators.Extensions;
using WowPacketParser.Generators.MetaModel;
using WowPacketParser.Generators.Templates;
using WowPacketParser.Shared.Attributes;

using Type = WowPacketParser.Generators.MetaModel.Type;

namespace WowPacketParser.Generators.HotfixParser
{
    internal class Template(ITypeSymbol type, IEnumerable<HotfixProperty> properties, IMethodSymbol constructor)
        : AbstractTemplate<Template>("HotfixExtensions")
    {
        public string[] Imports = [
            type.ContainingNamespace.GetFullyQualifiedName(),
            .. properties.SelectMany<HotfixProperty, string>(static property => [
                // ... Namespace of the property type
                property.Type.Namespace,
                // ... as well as the client build criterions
                property.AddedInVersion?.Type.Namespace ?? string.Empty,
                property.RemovedInVersion?.Type.Namespace ?? string.Empty
            ]).Where(x => x != string.Empty).Distinct().OrderBy(x => x)
        ];

        public readonly string Namespace = type.GetNamespace();
        public readonly string Name = type.GetName(false);
        public readonly string Kind = type.TypeKind switch
        {
            TypeKind.Class => "class",
            TypeKind.Struct => "struct",
            _ => throw new ArgumentOutOfRangeException(nameof(type.TypeKind))
        };
        public readonly Method Constructor = new(constructor);

        public readonly HotfixProperty[] Properties = [.. properties];
    }

    internal class HotfixProperty(IPropertySymbol property, IFieldSymbol field, ITypeSymbol type, Enumeration? addedInVersion, Enumeration? removedInVersion)
    {
        /// <summary>
        /// Name of the property.
        /// </summary>
        public readonly Property Property = new(property);

        /// <summary>
        /// Name of the backing field.
        /// </summary>
        public readonly Field Field = new(field);

        /// <summary>
        /// Type of the property.
        /// </summary>
        public readonly Type Type = new (type);
        
        public readonly Enumeration? AddedInVersion = addedInVersion;
        
        public readonly Enumeration? RemovedInVersion = removedInVersion;

        public readonly bool IsArray = type is IArrayTypeSymbol;
    }

    internal class ArrayProperty(IPropertySymbol property, IFieldSymbol field, IArrayTypeSymbol type, Enumeration? addedInVersion, Enumeration? removedInVersion)
        : HotfixProperty(property, field, type, addedInVersion, removedInVersion)
    {
        public readonly int Arity = type.GetArity();
    }
}
