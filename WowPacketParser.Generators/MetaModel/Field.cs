using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.MetaModel
{
    public readonly struct Field(Type type, string name)
    {
        public Field(IFieldSymbol field) : this(new(field.Type), field.Name) { }

        public readonly string Name = name;
        public readonly Type Type = type;
    }
}
