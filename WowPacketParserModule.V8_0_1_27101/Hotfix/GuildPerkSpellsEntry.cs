using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.GuildPerkSpells, HasIndexInData = false)]
    public class GuildPerkSpellsEntry
    {
        public int SpellID { get; set; }
    }
}
