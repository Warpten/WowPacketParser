using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.Curve, HasIndexInData = false)]
    public class CurveEntry
    {
        public byte Type { get; set; }
        public byte Flags { get; set; }
    }
}
