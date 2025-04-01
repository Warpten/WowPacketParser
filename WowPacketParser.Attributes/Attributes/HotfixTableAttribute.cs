using System.Resources;

namespace WowPacketParser.Shared.Attributes
{
    /// <summary>
    /// Marks the associated type as a hotfix table, as in a type that can parse hotfix information from a packet.
    /// 
    /// Types annotated with this method are expected to have a single partial constructor taking in:
    /// <list type="bullet">
    /// <item><description>A <see cref="Packet"/> if the ID of the record <b>is</b> inlined in the binary blob.</description></item>
    /// <item><description>A <see cref="Packet"/> and an integer if the ID of the record <b>is not</b> inlined in the binary blob.</description></item>
    /// </list>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HotfixTableAttribute<T> : Attribute // where T : Enum
    {
        /// <summary>
        /// The hash of the associated DB2.
        /// </summary>
        public T Hash { get; set; }
    }
}

