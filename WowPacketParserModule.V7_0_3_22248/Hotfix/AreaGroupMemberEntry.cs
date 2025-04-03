using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.AreaGroupMember, HasIndexInData = false)]
    public class AreaGroupMemberEntry
    {
        public ushort AreaGroupID { get; set; }
        public ushort AreaID { get; set; }
    }
}