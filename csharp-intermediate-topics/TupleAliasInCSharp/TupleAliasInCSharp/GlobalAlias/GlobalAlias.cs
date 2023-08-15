namespace TupleAliasInCSharp.GlobalAlias;

internal class GlobalAlias
{
    //ACCESS TUPLE WITH GLOBAL USING DIRECTIVE
    internal static void PrintTupleWithGlobalUsing()
    {
        TupleAliasGlobalUsing aliasGlobalUsing = (1, "Tuple alias declared with global using directive", 2);
        Console.WriteLine($"num1: {aliasGlobalUsing.num1}, str: {aliasGlobalUsing.str}, num2: {aliasGlobalUsing.num2}");
    }
}