using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.QuestLineXQuest, HasIndexInData = false)]
    public class QuestLineXQuestEntry
    {
        public uint QuestLineID { get; set; }
        public uint QuestID { get; set; }
        public uint OrderIndex { get; set; }
    }
}
