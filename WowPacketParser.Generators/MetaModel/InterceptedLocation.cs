using Microsoft.CodeAnalysis.CSharp;

namespace WowPacketParser.Generators.MetaModel
{
    public readonly struct InterceptedLocation(InterceptableLocation location)
    {
        public readonly InterceptableLocation Location = location;
        public string Target => Location.GetDisplayLocation();
    }
}
