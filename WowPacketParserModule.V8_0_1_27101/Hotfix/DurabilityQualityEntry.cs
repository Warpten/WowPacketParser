using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.DurabilityQuality, HasIndexInData = false)]
    public class DurabilityQualityEntry
    {
        public float Data { get; set; }
    }
}
