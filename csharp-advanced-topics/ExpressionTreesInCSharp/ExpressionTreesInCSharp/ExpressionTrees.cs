using System.Linq.Expressions;

namespace ExpressionTreesInCSharp;
public class ExpressionTrees
{
    public static Func<int, int, int> CreateLambdaExpression()
    {
        return (int number1, int number2) => number1 + number2;
    }

    public static Expression<Func<int, int, int>> CreateExpressionTreeFromLambdaExpression()
    {
        Expression<Func<int, int, int>> sumExpressionTree = (int number1, int number2) => number1 + number2;

        return sumExpressionTree;
    }

    public static Expression<Func<int, int, int>> CreateExpressionTreeUsingExpressionTreeClass()
    {
        ParameterExpression param1 = Expression.Parameter(typeof(int), "number1");
        ParameterExpression param2 = Expression.Parameter(typeof(int), "number2");

        BinaryExpression sumBody = Expression.Add(param1, param2);

        Expression<Func<int, int, int>> sumExpression = Expression.Lambda<Func<int, int, int>>(sumBody, param1, param2);

        return sumExpression;
    }

    public static Func<int, int, int> CompileExpressionTreeToLambdaExpression(Expression<Func<int, int, int>> expressionTree)
    {
        var delegateRepresentingLambdaExpression = expressionTree.Compile();

        return delegateRepresentingLambdaExpression;
    }
}
