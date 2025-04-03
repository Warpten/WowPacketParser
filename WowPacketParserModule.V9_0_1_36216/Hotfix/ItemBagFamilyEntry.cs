using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.ItemBagFamily, HasIndexInData = false)]
    public class ItemBagFamilyEntry
    {
        public string Name { get; set; }
    }
}
