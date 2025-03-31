namespace WowPacketParser.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class HotfixSerializerAttribute : Attribute
    {
        /// <summary>
        /// The path (on disk, relative to this file) to a template for the body of this serializer.
        /// </summary>
        public required string Template { get; set; }
    }
}

