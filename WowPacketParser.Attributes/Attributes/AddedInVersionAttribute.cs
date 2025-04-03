using System;
using System.Collections.Generic;
using System.Text;

using WowPacketParser.Shared.Enums;

namespace WowPacketParser.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AddedInVersionAttribute : Attribute
    {
        public ClientVersionBuild Version { get; set; }
    }
}
