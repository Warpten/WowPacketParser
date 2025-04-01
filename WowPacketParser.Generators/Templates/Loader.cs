using Scriban.Parsing;
using Scriban.Runtime;
using Scriban;
using System;
using System.IO;
using System.Threading.Tasks;
using Scriban.Syntax;

namespace WowPacketParser.Generators.Templates
{
    internal sealed class Loader : ITemplateLoader
    {
        private static readonly Lazy<Loader> _instance = new(() => new Loader());
        public static Loader Instance => _instance.Value;

        public Stream OpenTemplate(string templateName)
            => typeof(Loader).Assembly.GetManifestResourceStream(templateName);

        public string ToPath(string templateName)
            => templateName[0] == '$'
                ? $"WowPacketParser.Generators.Templates.Resources.{templateName.Slice(1)}.sbncs"
                : templateName + ".sbncs";

        public string GetPath(TemplateContext context, SourceSpan callerSpan, string templateName)
            => ToPath(templateName);

        public string Load(TemplateContext context, SourceSpan callerSpan, string templatePath)
        {
            using var dataStream = OpenTemplate(templatePath);
            using var reader = new StreamReader(dataStream);
            return reader.ReadToEnd();
        }

        public async ValueTask<string> LoadAsync(TemplateContext context, SourceSpan callerSpan, string templatePath)
        {
            using var dataStream = OpenTemplate(templatePath);
            using var reader = new StreamReader(dataStream);
            return await reader.ReadToEndAsync();
        }
    }
}
