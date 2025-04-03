using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.AchievementCategory)]
    public class AchievementCategoryEntry
    {
        public string Name { get; set; }
        public uint ID { get; set; }
        public short Parent { get; set; }
        public sbyte UiOrder { get; set; }
    }
}
