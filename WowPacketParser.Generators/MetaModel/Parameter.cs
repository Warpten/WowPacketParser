using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.MetaModel
{
    public readonly struct Parameter(Type type, string name)
    {
        public Parameter(IParameterSymbol parameter) : this(new(parameter.Type), parameter.Name) { }

        public readonly Type Type = type;
        public readonly string Name = name;
    }
}
