using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.LanguageWords, HasIndexInData = false)]
    public class LanguageWordsEntry
    {
        public string Word { get; set; }
        public uint LanguageID { get; set; }
    }
}
