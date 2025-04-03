using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WowPacketParser.Generators.Extensions
{
    internal static class SymbolExtensions
    {
        private static readonly SymbolDisplayFormat FullyQualifiedNameFormat = new(
                globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
                typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
                genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                miscellaneousOptions:
                    SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers |
                    SymbolDisplayMiscellaneousOptions.UseSpecialTypes);

        private static readonly SymbolDisplayFormat TypeFormat = new(
                globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
                typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
                genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                miscellaneousOptions:
                    SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers |
                    SymbolDisplayMiscellaneousOptions.UseSpecialTypes);

        private static readonly SymbolDisplayFormat TemplatelessTypeFormat = new(
                globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Omitted,
                typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypes,
                genericsOptions: SymbolDisplayGenericsOptions.None,
                miscellaneousOptions:
                    SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers |
                    SymbolDisplayMiscellaneousOptions.UseSpecialTypes);

        /// <summary>
        /// Returns the complete namespace of this symbol.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string GetNamespace(this ISymbol symbol)
            => symbol.ContainingNamespace.ToDisplayString(FullyQualifiedNameFormat);

        /// <summary>
        /// Returns the fully qualified name of this symbol.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(this ISymbol symbol)
            => symbol.ToDisplayString(FullyQualifiedNameFormat);

        /// <summary>
        /// Returns the name of this type symbol.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="omitTemplateArguments">A boolean indicating if template arguments should be omitted.</param>
        /// <returns></returns>
        public static string GetName(this ITypeSymbol type, bool omitTemplateArguments)
            => type.ToDisplayString(omitTemplateArguments ? TemplatelessTypeFormat : TypeFormat);

        /// <summary>
        /// Finds a specific attribute on this symbol.
        /// </summary>
        /// <param name="symbol">This symbol.</param>
        /// <param name="predicate">A predicate that filters all attributes.</param>
        /// <returns><pre>null</pre> if said attribute was not found exactly once.</returns>
        public static AttributeData? FindAttribute(this ISymbol symbol, Func<AttributeData, bool> predicate)
            => symbol.GetAttributes().Where(predicate).SingleOrDefault();

        /// <summary>
        /// Finds an attribute of the given type on this symbol.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to find.</typeparam>
        /// <param name="symbol">This symbol.</param>
        /// <returns>An enumerable over all attributes.</returns>
        public static AttributeData? FindAttribute<T>(this ISymbol symbol) where T : Attribute
            => FindAttribute(symbol, attributeData => attributeData.AttributeClass?.GetFullyQualifiedName() == typeof(T).FullName);

        /// <summary>
        /// Finds all attributes that match the given predicate on this symbol.
        /// </summary>
        /// <param name="symbol">This symbol.</param>
        /// <param name="predicate">A predicate that filters all attributes.</param>
        /// <returns>An enumerable over all attributes.</returns>
        public static IEnumerable<AttributeData> SelectAttributes(this ISymbol symbol, Func<AttributeData, bool> predicate)
        {
            var itr = symbol;
            while (itr != null)
            {
                foreach (var attr in itr.GetAttributes())
                    if (predicate(attr))
                        yield return attr;

                if (itr is ITypeSymbol typeSymbol)
                {
                    foreach (var implementedInterface in typeSymbol.AllInterfaces)
                        foreach (var attr in implementedInterface.GetAttributes())
                            if (predicate(attr))
                                yield return attr;

                    itr = typeSymbol.BaseType;
                }
                else
                    break;
            }
        }

        /// <summary>
        /// Finds all attributes of a given type on this symbol.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to find.</typeparam>
        /// <param name="symbol">This symbol.</param>
        /// <returns>An enumerable over all attributes.</returns>
        public static IEnumerable<AttributeData> SelectAttributes<T>(this ISymbol symbol) where T : Attribute
            => SelectAttributes(symbol, attributeData => attributeData.AttributeClass?.GetFullyQualifiedName() == typeof(T).FullName);

        /// <summary>
        /// Determines if a type is assignable from another type. Effectively checks that <paramref name="other"/> can be cast to <paramref name="symbol"/>.
        /// </summary>
        /// <param name="symbol">The type that a value must be assigned to.</param>
        /// <param name="other">The type of the value that is being assigned.</param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this ITypeSymbol symbol, ITypeSymbol other)
        {
            // Check through all base types
            var baseType = other;
            while (baseType != null)
            {
                if (SymbolEqualityComparer.Default.Equals(symbol, other))
                    return true;

                baseType = baseType.BaseType;
            }

            // Base type didn't match, try on interfaces
            // TODO: Consider non-recursive approach
            foreach (var implementedInterface in other.AllInterfaces)
                if (symbol.IsAssignableFrom(implementedInterface))
                    return true;

            return false;
        }

        /// <summary>
        /// Returns the backing field of this property. This function will only return a valid symbol if
        /// the property is auto-implemented.
        /// </summary>
        /// <param name="property">The property for which the backing field should be retrieved.</param>
        /// <returns>The backing field that corresponds to this property, or <pre>null</pre> if no such field could be found.</returns>
        public static IFieldSymbol GetBackingField(this IPropertySymbol property)
            => property.ContainingType.GetMembers()
                .Where(x => x.Kind == SymbolKind.Field)
                .Cast<IFieldSymbol>()
                .Where(x => SymbolEqualityComparer.Default.Equals(x.AssociatedSymbol, property) && x.IsImplicitlyDeclared)
                .SingleOrDefault();

        /// <summary>
        /// Checks that this type is a specialization of the given type.
        /// </summary>
        /// <param name="typeSymbol">A fully specified type symbol.</param>
        /// <param name="baseSymbol">A type symbol for which template parameters have not been specified.</param>
        /// <returns>True if the current type symbol is a specialization of the given unspecialized type.</returns>
        public static bool IsSpecializationOf(this ITypeSymbol typeSymbol, ITypeSymbol baseSymbol)
            => baseSymbol.IsAssignableFrom(typeSymbol.OriginalDefinition);

        public static ITypeSymbol? GetElementType(this ITypeSymbol typeSymbol)
        {
            if (typeSymbol is IArrayTypeSymbol arrayTypeSymbol)
                return arrayTypeSymbol.ElementType;

            switch (typeSymbol.SpecialType)
            {
                case SpecialType.System_Collections_Generic_ICollection_T:
                case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                case SpecialType.System_Collections_Generic_IList_T:
                case SpecialType.System_Collections_Generic_IReadOnlyList_T:
                case SpecialType.System_Collections_Generic_IEnumerable_T:
                case SpecialType.System_Collections_Generic_IEnumerator_T:
                    if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
                        return namedTypeSymbol.TypeArguments[0];
                    break;
            }

            return null;
        }
    }
}
