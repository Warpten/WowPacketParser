using Microsoft.CodeAnalysis;

using WowPacketParser.Generators.Extensions;

namespace WowPacketParser.Generators.MetaModel
{
    public readonly struct Type(string @namespace, string type)
    {
        public Type(ITypeSymbol type) : this(type.ContainingNamespace.GetFullyQualifiedName(), type.GetName(false)) { }

        public readonly string Namespace = @namespace;
        public readonly string Name = type;

        public readonly string FullyQualifiedName => $"{Namespace}.{Name}";
    }
}
