using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.ArtifactQuestXp, HasIndexInData = false)]
    public class ArtifactQuestXPEntry
    {
        [HotfixArray(10)]
        public uint[] Difficulty { get; set; }
    }
}
