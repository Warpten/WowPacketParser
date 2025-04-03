using WowPacketParser.Shared.Enums;

namespace WowPacketParser.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RemovedInVersionAttribute : Attribute
    {
        public ClientVersionBuild Version { get; set; }
    }
}
