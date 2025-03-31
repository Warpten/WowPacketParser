using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.Extensions
{
    internal static class AttributeDataExtensions
    {
        /// <summary>
        /// Finds a named argument within attribute data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="attributeName">The name of the argument to find.</param>
        /// <returns></returns>
        public static TypedConstant? FindNamedArgument(this AttributeData data, string attributeName)
        {
            foreach (var namedArgument in data.NamedArguments)
                if (namedArgument.Key == attributeName)
                    return namedArgument.Value;

            return null;
        }
    }
}
