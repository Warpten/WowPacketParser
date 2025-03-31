using System;
using System.Collections.Generic;
using System.Text;

namespace WowPacketParser.Generators
{
    internal record class Either<L, R>(L? Left, R? Right) { }
}
