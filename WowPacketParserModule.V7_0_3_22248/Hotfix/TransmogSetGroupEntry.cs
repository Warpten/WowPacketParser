using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V7_0_3_22248.Hotfix
{
    [HotfixStructure(DB2Hash.TransmogSetGroup)]
    public class TransmogSetGroupEntry
    {
        public string Label { get; set; }
        public uint ID { get; set; }
    }
}
