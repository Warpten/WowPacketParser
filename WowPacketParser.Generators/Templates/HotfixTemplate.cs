using System.Collections.Generic;
using System.Linq;
using WowPacketParser.Generators.MetaModel;
using Type = WowPacketParser.Generators.MetaModel.Type;

namespace WowPacketParser.Generators.Templates
{
    internal class HotfixTemplate(IEnumerable<HotfixType> types) : AbstractTemplate<HotfixTemplate>("")
    {
        public string[] Imports = [.. types.SelectMany<HotfixType, string>(static type => [
            // Namespace of the type.
            type.Namespace,
            // For each property...
            .. type.Properties.SelectMany<HotfixProperty, string>(static property => [
                // ... Namespace of the property type
                property.Type.Namespace,
                // ... as well as the client build criterions
                property.AddedInVersion?.Type.Namespace ?? string.Empty,
                property.RemovedInVersion?.Type.Namespace ?? string.Empty
            ])
        ]).Where(x => x != string.Empty).Distinct().OrderBy(x => x)];

        public HotfixType[] Types = [.. types];
    }

    internal class HotfixType(string name, string @namespace, IEnumerable<HotfixProperty> properties)
    {
        public readonly string Namespace = @namespace;
        public readonly string Name = name;
        public readonly HotfixProperty[] Properties = [.. properties];
    }

    internal class HotfixProperty(string name, ITypeSymbol type, Enumeration? addedInVersion, Enumeration? removedInVersion)
    {
        public readonly string Name = name;
        public readonly Type Type = new (type.IsArray ? type.ElementType : type);
        public readonly Enumeration? AddedInVersion = addedInVersion;
        public readonly Enumeration? RemovedInVersion = removedInVersion;

        public readonly bool IsArray = type.IsArray;
        public readonly int Arity = type.FindAttribute<ArraySizeAttribute>()?.FindNamedArgument(nameof(ArraySizeAttribute.Size))?.ToInteger() ?? 0;
    }
}
