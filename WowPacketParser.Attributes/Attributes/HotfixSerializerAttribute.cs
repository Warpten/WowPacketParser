namespace WowPacketParser.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class HotfixSerializerAttribute : Attribute
    {
        /// <summary>
        /// The name of the resource. Such a resource lives within the target assembly.
        /// </summary>
        public string Resource { get; set; } = null;
    }
}

