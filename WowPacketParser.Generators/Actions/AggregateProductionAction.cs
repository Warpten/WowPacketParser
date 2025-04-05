using System.Collections.Generic;

using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.Actions
{
    internal sealed class AggregateProductionAction(IEnumerable<IProductionAction> actions) : IProductionAction
    {
        public AggregateProductionAction(params IProductionAction[] actions) : this((IEnumerable<IProductionAction>) actions) { }

        private IEnumerable<IProductionAction> Actions = actions;

        public void Run(SourceProductionContext context)
        {
            foreach (var action in Actions)
                action.Run(context);
        }
    }
}
