using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.TransmogSetGroup)]
    public class TransmogSetGroupEntry
    {
        public string Name { get; set; }
        public uint ID { get; set; }
    }
}
