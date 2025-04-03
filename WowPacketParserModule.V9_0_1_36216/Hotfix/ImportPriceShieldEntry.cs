using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.ImportPriceShield, HasIndexInData = false)]
    public class ImportPriceShieldEntry
    {
        public float Data { get; set; }
    }
}
