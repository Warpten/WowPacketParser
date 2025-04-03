using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.BannedAddons, HasIndexInData = false)]
    public class BannedAddOnsEntry
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public byte Flags { get; set; }
    }
}