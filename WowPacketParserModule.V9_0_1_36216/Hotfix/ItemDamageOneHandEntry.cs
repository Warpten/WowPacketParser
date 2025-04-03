using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.ItemDamageOneHand, HasIndexInData = false)]
    public class ItemDamageOneHandEntry
    {
        public ushort ItemLevel { get; set; }
        [HotfixArray(7)]
        public float[] Quality { get; set; }
    }
}
