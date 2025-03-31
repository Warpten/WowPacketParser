using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.MetaModel
{
    public readonly struct Property(Type type, string name)
    {
        public Property(IPropertySymbol property) : this(new(property.Type), property.Name) { }

        public readonly string Name = name;
        public readonly Type Type = type;
    }
}
