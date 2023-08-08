namespace TupleAliasInCSharp
{
    using tupleAliasUsing = (int num1, string str, double num2);
    public class TupleAlias
    {
        public static void PrintTupleValues()
        {
            //ACCESS TUPLE WITH GLOBAL USING DIRECTIVE
            tupleAliasGlobalUsing aliasGlobalUsing = (1, "Tuple alias declared with global using directive", 6);
            Console.WriteLine($"num1: {aliasGlobalUsing.num1}, str: {aliasGlobalUsing.str}, num2: {aliasGlobalUsing.num2}");
            Console.WriteLine();

            //ACCESS TUPLE WITH USING DIRECTIVE
            tupleAliasUsing aliasUsing = (10, "Tuple alias declared with using directive", 2.2);
            Console.WriteLine($"num1: {aliasUsing.num1}, str: {aliasUsing.str}, num2: {aliasUsing.num2}");

            //DECONSTRUCT TUPLE USING ALIAS NAME
            Console.WriteLine("Deconstruct tuple without using 'var' keyword");
            (int a, string str, int b) = aliasGlobalUsing;
            Console.WriteLine($"num1: {a}, str: {str}, num2: {b}");    
            
            //DECONSTRUCT TUPLE USING 'var' KEYWORD
            Console.WriteLine("Deconstruct tuple using 'var' keyword");
            var (a1, str1, b1) = aliasGlobalUsing;
            Console.WriteLine($"num1: {a1}, str: {str1}, num2: {b1}");

            // TUPLE ASSIGNMENT - the field names need not match, only the types and the arity need to match
            aliasUsing = aliasGlobalUsing;
            Console.WriteLine($"num1: {aliasUsing.num1}, str: {aliasUsing.str}, num2: {aliasUsing.num2}");            

            //This will generate error as (int, string, double) cannot to converted to (int, string, int).Use explicit conversion
            //tupleAliasGlobalUsing temp1 = aliasUsing;
        }
    }
}
