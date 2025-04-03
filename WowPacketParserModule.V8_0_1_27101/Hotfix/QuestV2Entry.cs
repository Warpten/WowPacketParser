using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.QuestV2, HasIndexInData = false)]
    public class QuestV2Entry
    {
        public ushort UniqueBitFlag { get; set; }
    }
}
