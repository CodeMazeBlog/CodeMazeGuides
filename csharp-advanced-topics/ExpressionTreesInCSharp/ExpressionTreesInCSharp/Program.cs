using ExpressionTreesInCSharp.EntityFramework;
using System.Linq.Expressions;

namespace ExpressionTreesInCSharp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Create and Execute Expression Tree From Lambda Expression");
        var sumExpressionTree = ExpressionTrees.CreateExpressionTreeFromLambdaExpression();
        Console.WriteLine(sumExpressionTree.Compile()(1, 2));

        Console.WriteLine("Printing the properties of the Expression Tree in Root Node");
        Console.WriteLine(sumExpressionTree.NodeType);
        Console.WriteLine(sumExpressionTree.Parameters[0].Name);
        Console.WriteLine(sumExpressionTree.Parameters[1].Name);
        Console.WriteLine(sumExpressionTree.Body.ToString());
        Console.WriteLine(sumExpressionTree.ReturnType);
        Console.WriteLine(sumExpressionTree.Body.NodeType);

        Console.WriteLine("Printing the properties of Left Node");
        BinaryExpression body = (BinaryExpression)sumExpressionTree.Body;
        Console.WriteLine(body.Left.NodeType);
        ParameterExpression leftParam = (ParameterExpression)body.Left;
        Console.WriteLine(leftParam.Name);

        Console.WriteLine("Printing the properties of Right Node");
        Console.WriteLine(body.Right.NodeType);
        ParameterExpression rightParam = (ParameterExpression)body.Right;

        Console.WriteLine(rightParam.Name);

        Console.WriteLine("Create, Compile and Execute Expression Tree From Expression Class API");
        var sumFromClass = ExpressionTrees.CreateExpressionTreeUsingExpressionTreeClass();

        Console.WriteLine(ExpressionTrees.CompileExpressionTreeToLambdaExpression(sumFromClass)(1, 2));

        Console.WriteLine("Inspecting EF Core Query:");
        var efCore = new EntityFrameworkSqlite();

        Console.WriteLine("Translated Query to List Users:");
        Console.WriteLine(efCore.GetUsersListQuery() + "\n");

        Console.WriteLine("Translated Query to Filter Users:");
        Console.WriteLine(efCore.GetWhereQuery());
    }
}
