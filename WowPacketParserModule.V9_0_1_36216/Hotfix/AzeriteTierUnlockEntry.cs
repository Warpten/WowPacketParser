using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.AzeriteTierUnlock, HasIndexInData = false)]
    public class AzeriteTierUnlockEntry
    {
        public byte ItemCreationContext { get; set; }
        public byte Tier { get; set; }
        public byte AzeriteLevel { get; set; }
        public uint AzeriteTierUnlockSetID { get; set; }
    }
}
