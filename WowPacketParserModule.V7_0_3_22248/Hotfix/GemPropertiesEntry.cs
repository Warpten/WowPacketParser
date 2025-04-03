using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.GemProperties, HasIndexInData = false)]
    public class GemPropertiesEntry
    {
        public uint Type { get; set; }
        public ushort EnchantID { get; set; }
        public ushort MinItemLevel { get; set; }
    }
}