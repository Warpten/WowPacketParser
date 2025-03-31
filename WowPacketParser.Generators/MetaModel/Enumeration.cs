namespace WowPacketParser.Generators.MetaModel
{
    public readonly struct Enumeration(Type type, string memberName)
    {
        public readonly string Name = memberName;
        public readonly Type Type = type;
    }
}
