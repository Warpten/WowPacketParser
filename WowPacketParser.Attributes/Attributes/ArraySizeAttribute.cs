using System;
using System.Collections.Generic;
using System.Text;

namespace WowPacketParser.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ArraySizeAttribute : Attribute
    {
        public int Size { get; set; }
    }
}
