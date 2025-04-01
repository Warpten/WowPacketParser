using Microsoft.CodeAnalysis;
using System.Linq;
using WowPacketParser.Generators.MetaModel;
using WowPacketParser.Shared.Attributes;

using Type = WowPacketParser.Generators.MetaModel.Type;

namespace WowPacketParser.Generators.Extensions
{
    public static class TypedConstantExtensions
    {
        public static int? AsInt32(this TypedConstant constant)
            => constant.Kind == TypedConstantKind.Primitive && constant.Type?.SpecialType == SpecialType.System_Int32
                ? (int) constant.Value!
                : null;

        public static uint? AsUInt32(this TypedConstant constant)
            => constant.Kind == TypedConstantKind.Primitive && constant.Type?.SpecialType == SpecialType.System_UInt32
                ? (uint)constant.Value!
                : null;

        public static string? AsString(this TypedConstant constant)
            => constant.Kind == TypedConstantKind.Primitive && constant.Type?.SpecialType == SpecialType.System_String
                ? (string) constant.Value!
                : null;

        public static int GetArity(this ITypeSymbol symbol)
        {
            // If the type is an array ...
            if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                // ... and there is a size specified - but only 1-dimensional arrays, return that size.
                if (arrayTypeSymbol.Sizes.Length == 1)
                    return arrayTypeSymbol.Sizes[0];

                // ... Else read the size attribute.
                var sizeAttribute = symbol.FindAttribute<ArraySizeAttribute>()?.FindArgument(nameof(ArraySizeAttribute.Size));
                if (sizeAttribute.HasValue)
                    return sizeAttribute.Value.AsInt32() ?? 0;
            }
            
            // C#8: Inline arrays
            // WPP doesn't use these, but futureproof.
            var inlineArray = symbol.FindAttribute(attr => attr.AttributeClass?.GetFullyQualifiedName() == "System.Runtime.CompilerServices.InlineArrayAttribute");
            if (inlineArray != null)
                return inlineArray.FindArgument("Length", 0)?.AsInt32() ?? 0;

            return 0;
        }

        public static Enumeration? ToEnumeration(this TypedConstant constant)
        {
            if (constant.Kind != TypedConstantKind.Enum)
                return null;

            if (constant.Type is not INamedTypeSymbol enumerationType)
                return null;

            var enumerationMember = enumerationType.GetMembers()
                .OfType<IFieldSymbol>()
                .SingleOrDefault(f => f.HasConstantValue && (f.ConstantValue?.Equals(constant.Value) ?? false));

            if (enumerationMember == null)
                return null;

            return new Enumeration(new Type(constant.Type), enumerationMember.Name);
        }
    }
}
