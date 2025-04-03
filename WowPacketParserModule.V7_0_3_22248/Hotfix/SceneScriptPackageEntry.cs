using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.SceneScriptPackage, HasIndexInData = false)]
    public class SceneScriptPackageEntry
    {
        public string Name { get; set; }
    }
}
