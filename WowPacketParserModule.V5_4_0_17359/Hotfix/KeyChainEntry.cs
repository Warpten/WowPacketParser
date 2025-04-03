using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V5_4_0_17359.Hotfix
{
    [HotfixStructure(DB2Hash.Keychain)]
    public class KeyChainEntry
    {
        public int KeychainID { get; set; }
        [HotfixArray(32)]
        public byte[] Key { get; set; }
    }
}
