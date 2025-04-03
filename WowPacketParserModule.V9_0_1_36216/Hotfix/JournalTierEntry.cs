using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.JournalTier, HasIndexInData = false)]
    public class JournalTierEntry
    {
        public string Name { get; set; }
        public int PlayerConditionID { get; set; }
    }
}
