namespace ParamsKeyword;

public static class ParamsSignatures
{
    public static string StringBeforeStringParams(string requiredStringArgument, params string[] items)
        => $"{requiredStringArgument} + {items.Length}";

    public static string ArrayBeforeParams(string[] requiredArray, params string[] items)
        => $"{requiredArray.Length} + {items.Length}";

    public static string OtherArgumentsBeforeParams(int requiredParam, bool optionalBool = true, params string[] items)
        => $"{requiredParam}, {optionalBool}, {items.Length}";

    public static string UseParamsWithNamedArguments(int firstArgument, params string[] items)
        => $"{firstArgument} + {items.Length}";

    public static int CountObjects(params object[] items) => items.Length;
}
