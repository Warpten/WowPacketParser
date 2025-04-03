using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.ArtifactPowerLink, HasIndexInData = false)]
    public class ArtifactPowerLinkEntry
    {
        public ushort PowerA { get; set; }
        public ushort PowerB { get; set; }
    }
}
