using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.GarrPlotInstance, HasIndexInData = false)]
    public class GarrPlotInstanceEntry
    {
        public string Name { get; set; }
        public byte GarrPlotID { get; set; }
    }
}
