using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.AzeritePower, HasIndexInData = false)]
    public class AzeritePowerEntry
    {
        public int SpellID { get; set; }
        public int ItemBonusListID { get; set; }
        public int SpecSetID { get; set; }
        public int Flags { get; set; }
    }
}
