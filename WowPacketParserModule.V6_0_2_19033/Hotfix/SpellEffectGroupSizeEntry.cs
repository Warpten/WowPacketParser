using System;
using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V6_0_2_19033.Hotfix
{
    [HotfixStructure(DB2Hash.SpellEffectGroupSize)]
    public class SpellEffectGroupSizeEntry
    {
        public uint ID { get; set; }
        public uint SpellEffectID { get; set; }
        public Single Size { get; set; }
    }
}