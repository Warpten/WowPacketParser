using Microsoft.CodeAnalysis;

namespace WowPacketParser.Generators.Extensions
{
    internal static class AttributeDataExtensions
    {
        /// <summary>
        /// Finds an argument within the attribute data.
        /// </summary>
        /// <param name="data">The attribute data to search into.</param>
        /// <param name="argumentName">The name of the argument to find. If null, named arguments will not be traversed.</param>
        /// <param name="argumentIndex">The index of the argument to find. If -1, constructor arguments will not be traversed.</param>
        /// <returns></returns>
        public static TypedConstant? FindArgument(this AttributeData data, string? argumentName = null, int argumentIndex = -1)
        {
            if (argumentName != null)
            {
                foreach (var namedArgument in data.NamedArguments)
                    if (namedArgument.Key == argumentName)
                        return namedArgument.Value;
            }

            if (argumentIndex >= 0 && data.ConstructorArguments.Length > argumentIndex)
                return data.ConstructorArguments[argumentIndex];

            return null;
        }
    }
}
