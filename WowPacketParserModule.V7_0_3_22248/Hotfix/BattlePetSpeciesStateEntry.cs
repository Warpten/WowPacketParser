using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.BattlePetSpeciesState, HasIndexInData = false)]
    public class BattlePetSpeciesStateEntry
    {
        public int Value { get; set; }
        public ushort SpeciesID { get; set; }
        public byte State { get; set; }
    }
}