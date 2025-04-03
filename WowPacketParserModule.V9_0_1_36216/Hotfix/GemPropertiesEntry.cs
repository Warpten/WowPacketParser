using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.GemProperties, HasIndexInData = false)]
    public class GemPropertiesEntry
    {
        public ushort EnchantId { get; set; }
        public int Type { get; set; }
    }
}
