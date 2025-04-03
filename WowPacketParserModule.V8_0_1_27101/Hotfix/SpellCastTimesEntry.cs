using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.SpellCastTimes, HasIndexInData = false)]
    public class SpellCastTimesEntry
    {
        public int Base { get; set; }
        public short PerLevel { get; set; }
        public int Minimum { get; set; }
    }
}
