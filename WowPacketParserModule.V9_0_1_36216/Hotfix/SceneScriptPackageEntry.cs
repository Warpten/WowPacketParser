using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.SceneScriptPackage, HasIndexInData = false)]
    public class SceneScriptPackageEntry
    {
        public string Name { get; set; }
    }
}
