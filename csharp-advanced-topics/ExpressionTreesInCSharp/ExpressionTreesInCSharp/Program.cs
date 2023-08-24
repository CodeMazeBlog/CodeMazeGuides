using ExpressionTreesInCSharp.EntityFramework;
using System.Linq.Expressions;

namespace ExpressionTreesInCSharp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Create Expression Tree From Lambda Expression");
        var sumExpressionTreeFromLambdaExpression = ExpressionTrees.CreateExpressionTreeFromLambdaExpression();

        Console.WriteLine("Create Expression Tree From Expression Class API");
        var sumExpressionTreeFromExpressionApi = ExpressionTrees.CreateExpressionTreeUsingExpressionTreeClass();

        Console.WriteLine("Compile and Execute Expression Tree");
        var delegateSumExpressionTree = ExpressionTrees.CompileExpressionTreeToLambdaExpression(sumExpressionTreeFromLambdaExpression)(1, 2);
        Console.WriteLine(delegateSumExpressionTree);
        var delegateSumExpressionTreeFromExpressionApi = ExpressionTrees.CompileExpressionTreeToLambdaExpression(sumExpressionTreeFromExpressionApi)(1, 2);
        Console.WriteLine(delegateSumExpressionTreeFromExpressionApi);

        Console.WriteLine("Printing the properties of the Expression Tree in Root Node");
        Console.WriteLine(sumExpressionTreeFromLambdaExpression.NodeType);
        Console.WriteLine(sumExpressionTreeFromLambdaExpression.Parameters[0].Name);
        Console.WriteLine(sumExpressionTreeFromLambdaExpression.Parameters[1].Name);
        Console.WriteLine(sumExpressionTreeFromLambdaExpression.Body.ToString());
        Console.WriteLine(sumExpressionTreeFromLambdaExpression.ReturnType);
        Console.WriteLine(sumExpressionTreeFromLambdaExpression.Body.NodeType);

        Console.WriteLine("Printing the properties of Left Node");
        BinaryExpression body = (BinaryExpression)sumExpressionTreeFromLambdaExpression.Body;
        Console.WriteLine(body.Left.NodeType);
        ParameterExpression leftParam = (ParameterExpression)body.Left;
        Console.WriteLine(leftParam.Name);

        Console.WriteLine("Printing the properties of Right Node");
        Console.WriteLine(body.Right.NodeType);
        ParameterExpression rightParam = (ParameterExpression)body.Right;

        Console.WriteLine(rightParam.Name);

        Console.WriteLine("Inspecting EF Core Query:");
        var efCore = new EntityFrameworkSqlite();

        Console.WriteLine("Translated Query to List Users:");
        Console.WriteLine(efCore.GetUsersListQuery() + "\n");

        Console.WriteLine("Translated Query to Filter Users:");
        Console.WriteLine(efCore.GetWhereQuery());
    }
}
