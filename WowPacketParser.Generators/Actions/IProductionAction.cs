using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.Actions
{
    internal interface IProductionAction
    {
        public void Run(SourceProductionContext context);
    }

    internal static class ProductionActionExtensions
    {
        public static AggregateProductionAction And<T, U>(this T left, U right)
            where T : IProductionAction
            where U : IProductionAction
            => new AggregateProductionAction(left, right);

        public static AggregateProductionAction ToProductionAction(this IEnumerable<IProductionAction> actions)
            => new(actions);
    }
}
