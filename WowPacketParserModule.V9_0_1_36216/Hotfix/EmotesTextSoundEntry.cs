using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V9_0_1_36216.Hotfix
{
    [HotfixStructure(DB2Hash.EmotesTextSound, HasIndexInData = false)]
    public class EmotesTextSoundEntry
    {
        public byte RaceID { get; set; }
        public byte ClassID { get; set; }
        public byte SexID { get; set; }
        public uint SoundID { get; set; }
        public ushort EmotesTextID { get; set; }
    }
}
