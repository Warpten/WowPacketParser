using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.GuildColorBorder, HasIndexInData = false)]
    public class GuildColorBorderEntry
    {
        public byte Red { get; set; }
        public byte Blue { get; set; }
        public byte Green { get; set; }
    }
}
