using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.PrestigeLevelInfo, HasIndexInData = false)]
    public class PrestigeLevelInfoEntry
    {
        public string Name { get; set; }
        public int PrestigeLevel { get; set; }
        public int BadgeTextureFileDataID { get; set; }
        public byte Flags { get; set; }
        public int AwardedAchievementID { get; set; }
    }
}
