using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.SpellTotems, HasIndexInData = false)]
    public class SpellTotemsEntry
    {
        public int SpellID { get; set; }
        [HotfixArray(2)]
        public ushort[] RequiredTotemCategoryID { get; set; }
        [HotfixArray(2)]
        public int[] Totem { get; set; }
    }
}
