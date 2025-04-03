using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.QuestSort, HasIndexInData = false)]
    public class QuestSortEntry
    {
        public string SortName { get; set; }
        public sbyte UiOrderIndex { get; set; }
    }
}
