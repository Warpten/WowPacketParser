using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.QuestXp, HasIndexInData = false)]
    public class QuestXPEntry
    {
        [HotfixArray(10)]
        public ushort[] Difficulty { get; set; }
    }
}
