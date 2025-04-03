using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.NamesReservedLocale, HasIndexInData = false)]
    public class NamesReservedLocaleEntry
    {
        public string Name { get; set; }
        public byte LocaleMask { get; set; }
    }
}
