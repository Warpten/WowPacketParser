using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.ChrClassesXPowerTypes, HasIndexInData = false)]
    public class ChrClassesXPowerTypesEntry
    {
        public sbyte PowerType { get; set; }
        public byte ClassID { get; set; }
    }
}
