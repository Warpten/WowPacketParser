using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.BattlePetBreedQuality, HasIndexInData = false)]
    public class BattlePetBreedQualityEntry
    {
        public float Modifier { get; set; }
        public byte Quality { get; set; }
    }
}