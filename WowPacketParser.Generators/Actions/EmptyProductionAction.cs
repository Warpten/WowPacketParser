using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.Actions
{
    internal class EmptyProductionAction : IProductionAction
    {
        public static readonly EmptyProductionAction Instance = new ();

        private EmptyProductionAction() { }

        public void Run(SourceProductionContext context) { }
    }
}
