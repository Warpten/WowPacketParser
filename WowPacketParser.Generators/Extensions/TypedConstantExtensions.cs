using Microsoft.CodeAnalysis;
using System.Linq;
using WowPacketParser.Generators.MetaModel;
using Type = WowPacketParser.Generators.MetaModel.Type;

namespace WowPacketParser.Generators.Extensions
{
    public static class TypedConstantExtensions
    {
        public static int? ToInt32(this TypedConstant constant)
            => constant.Kind == TypedConstantKind.Primitive && constant.Type == SpecialType.System_Int32
                ? (int) constant.Value!
                : null;

        public static int? ToUInt32(this TypedConstant constant)
            => constant.Kind == TypedConstantKind.Primitive && constant.Type == SpecialType.System_UInt32
                ? (uint) constant.Value!
                : null;

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
