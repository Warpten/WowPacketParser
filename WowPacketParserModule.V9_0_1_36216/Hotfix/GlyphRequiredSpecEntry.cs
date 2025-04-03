using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.GlyphRequiredSpec, HasIndexInData = false)]
    public class GlyphRequiredSpecEntry
    {
        public ushort ChrSpecializationID { get; set; }
        public ushort GlyphPropertiesID { get; set; }
    }
}
