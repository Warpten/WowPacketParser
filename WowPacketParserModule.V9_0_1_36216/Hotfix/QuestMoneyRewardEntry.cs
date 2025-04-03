using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.QuestMoneyReward, HasIndexInData = false)]
    public class QuestMoneyRewardEntry
    {
        [HotfixArray(10)]
        public uint[] Difficulty { get; set; }
    }
}
