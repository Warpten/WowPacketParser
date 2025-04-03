using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.GarrPlotBuilding, HasIndexInData = false)]
    public class GarrPlotBuildingEntry
    {
        public byte GarrPlotID { get; set; }
        public byte GarrBuildingID { get; set; }
    }
}