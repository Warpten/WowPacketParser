using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_1_0_39185.Hotfix
{
    [HotfixStructure(DB2Hash.ChrCustomizationDisplayInfo, ClientVersionBuild.V9_1_0_39185, HasIndexInData = false)]
    public class ChrCustomizationDisplayInfoEntry
    {
        public int ShapeshiftFormID { get; set; }
        public int DisplayID { get; set; }
        public float BarberShopMinCameraDistance { get; set; }
        public float BarberShopHeightOffset { get; set; }
    }
}
