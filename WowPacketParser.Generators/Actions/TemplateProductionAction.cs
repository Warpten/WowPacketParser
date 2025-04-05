using Microsoft.CodeAnalysis;

using WowPacketParser.Generators.Templates;

namespace WowPacketParser.Generators.Actions
{
    internal class TemplateProductionAction<T>(string name, T template) : IProductionAction where T : AbstractTemplate<T>
    {
        public readonly string Name = name;
        public readonly T Template = template;

        public void Run(SourceProductionContext context)
            => context.AddSource(Name, Template.Render());
    }
}
