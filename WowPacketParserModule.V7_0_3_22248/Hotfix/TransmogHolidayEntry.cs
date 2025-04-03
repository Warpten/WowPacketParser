using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.TransmogHoliday, HasIndexInData = false)]
    public class TransmogHolidayEntry
    {
        public uint HolidayID { get; set; }
    }
}
