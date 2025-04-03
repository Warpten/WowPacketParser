using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.ItemLimitCategory, HasIndexInData = false)]
    public class ItemLimitCategoryEntry
    {
        public string Name { get; set; }
        public byte Quantity { get; set; }
        public byte Flags { get; set; }
    }
}
