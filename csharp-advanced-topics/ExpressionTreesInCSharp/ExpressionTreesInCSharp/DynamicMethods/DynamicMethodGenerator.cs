using System.Linq.Expressions;

namespace ExpressionTreesInCSharp.DynamicMethods;
public class DynamicMethodGenerator
{
    public static Func<int, int, int> GenerateExecutableFunctionFromMathStatement(string mathStatement)
    {
        // Parse the math statement
        var parts = mathStatement.Split('=');
        var variables = parts[1].Split('*');

        var left = Expression.Parameter(typeof(int), variables[0]);
        var right = Expression.Parameter(typeof(int), variables[1]);

        // Create the expression tree
        var add = Expression.Multiply(left, right);
        var lambda = Expression.Lambda(add, left, right);

        // Return the compiled method
        return (Func<int, int, int>)lambda.Compile();
    }
}
