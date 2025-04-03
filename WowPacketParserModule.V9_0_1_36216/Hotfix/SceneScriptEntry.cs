using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.SceneScript, HasIndexInData = false)]
    public class SceneScriptEntry
    {
        public ushort FirstSceneScriptID { get; set; }
        public ushort NextSceneScriptID { get; set; }
    }
}
