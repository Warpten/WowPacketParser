using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.NamesProfanity, HasIndexInData = false)]
    public class NamesProfanityEntry
    {
        public string Name { get; set; }
        public sbyte Language { get; set; }
    }
}