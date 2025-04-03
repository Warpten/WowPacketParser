using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_1_0_39185.Hotfix
{
    [HotfixStructure(DB2Hash.NumTalentsAtLevel, ClientVersionBuild.V9_1_0_39185, HasIndexInData = false)]
    public class NumTalentsAtLevelEntry
    {
        public int NumTalents { get; set; }
        public int NumTalentsDeathKnight { get; set; }
        public int NumTalentsDemonHunter { get; set; }
    }
}
