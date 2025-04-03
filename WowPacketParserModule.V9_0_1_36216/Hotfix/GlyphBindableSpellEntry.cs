using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.GlyphBindableSpell, HasIndexInData = false)]
    public class GlyphBindableSpellEntry
    {
        public int SpellID { get; set; }
        public short GlyphPropertiesID { get; set; }
    }
}
