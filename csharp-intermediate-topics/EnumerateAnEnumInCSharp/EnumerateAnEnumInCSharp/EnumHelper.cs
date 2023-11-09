using System.Reflection;

namespace EnumerateAnEnumInCSharp
{
    public static class EnumHelper
    {
        public static Array GetValues(Type type)
        {
            return Enum.GetValues(type);
        }

        public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues<TEnum>();
        }

        public static TEnum[] GetValuesWithReflection<TEnum>() where TEnum : struct, Enum
        {
            FieldInfo[] fields = typeof(TEnum).GetFields(BindingFlags.Static | BindingFlags.Public);

            return fields.Select(x => x.GetValue(null))
                .Cast<TEnum>()
                .ToArray();
        }
    }
}