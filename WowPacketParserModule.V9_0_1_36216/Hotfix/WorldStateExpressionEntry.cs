using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.WorldStateExpression, HasIndexInData = false)]
    public class WorldStateExpressionEntry
    {
        public string Expression { get; set; }
    }
}
