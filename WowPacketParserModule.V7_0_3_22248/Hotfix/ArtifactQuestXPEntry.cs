using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.ArtifactQuestXp, HasIndexInData = false)]
    public class ArtifactQuestXPEntry
    {
        [HotfixArray(10)]
        public uint[] Exp { get; set; }
    }
}
