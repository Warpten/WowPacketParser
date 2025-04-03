using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.BankBagSlotPrices, HasIndexInData = false)]
    public class BankBagSlotPricesEntry
    {
        public uint Cost { get; set; }
    }
}