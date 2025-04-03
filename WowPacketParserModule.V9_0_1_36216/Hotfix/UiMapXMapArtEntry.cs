using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.UiMapXMapArt, HasIndexInData = false)]
    public class UiMapXMapArtEntry
    {
        public int PhaseID { get; set; }
        public int UiMapArtID { get; set; }
        public uint UiMapID { get; set; }
    }
}
