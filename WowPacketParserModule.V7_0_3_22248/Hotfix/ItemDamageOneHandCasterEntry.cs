using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.ItemDamageOneHandCaster, HasIndexInData = false)]
    public class ItemDamageOneHandCasterEntry
    {
        [HotfixArray(7)]
        public float[] DPS { get; set; }
        public ushort ItemLevel { get; set; }
    }
}