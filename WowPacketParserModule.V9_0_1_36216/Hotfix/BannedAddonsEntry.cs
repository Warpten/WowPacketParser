using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.BannedAddons, HasIndexInData = false)]
    public class BannedAddonsEntry
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public byte Flags { get; set; }
    }
}
