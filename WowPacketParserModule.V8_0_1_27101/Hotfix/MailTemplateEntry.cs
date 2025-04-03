using WowPacketParser.Enums;
using WowPacketParser.Hotfix;
using WowPacketParser.Shared.Enums;

namespace WowPacketParserModule.V8_0_1_27101.Hotfix
{
    [HotfixStructure(DB2Hash.MailTemplate, HasIndexInData = false)]
    public class MailTemplateEntry
    {
        public string Body { get; set; }
    }
}
