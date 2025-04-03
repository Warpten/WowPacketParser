using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.ItemCurrencyCost, HasIndexInData = false)]
    public class ItemCurrencyCostEntry
    {
        public uint ItemId { get; set; }
    }
}