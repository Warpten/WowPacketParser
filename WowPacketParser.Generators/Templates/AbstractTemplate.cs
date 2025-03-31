using Scriban.Runtime;
using Scriban;
using System.IO;
using System.Reflection;

namespace WowPacketParser.Generators.Templates
{

    internal abstract class AbstractTemplate<T> where T : AbstractTemplate<T>
    {
        private readonly Template _template;
        private readonly TemplateContext _context;
        private readonly ScriptObject _globalState;

        protected AbstractTemplate(Stream resource, string filePath) : base()
        {
            using var reader = new StreamReader(resource);
            _template = Template.Parse(reader.ReadToEnd(), filePath);

            _context = new TemplateContext()
            {
                MemberRenamer = member => member.Name,
                MemberFilter = member => member switch
                {
                    FieldInfo field => IsEligible(field),
                    PropertyInfo prop => IsEligible(prop),
                    MethodInfo method => IsEligible(method),
                    _ => false
                },
                TemplateLoader = Loader.Instance
            };

            // Add language extensions to the global state.
            _globalState = new ScriptObject();
            _globalState.Import(typeof(LanguageExtensions), ScriptMemberImportFlags.Method, null, member => member.Name);

        }

        protected AbstractTemplate(string name) : this(Loader.Instance.OpenTemplate(Loader.Instance.ToPath(name)), name) { }

        public string Render()
        {
            _globalState.Add("model", this);
            _context.PushGlobal(_globalState);
            return _template.Render(_context);
        }

        private static bool IsEligible(FieldInfo fieldInfo) => fieldInfo.IsPublic && fieldInfo.IsInitOnly && !fieldInfo.IsStatic;
        private static bool IsEligible(PropertyInfo propInfo) => IsEligible(propInfo.GetGetMethod());
        private static bool IsEligible(MethodInfo methodInfo) => methodInfo.IsPublic && !methodInfo.IsStatic;
    }
}
