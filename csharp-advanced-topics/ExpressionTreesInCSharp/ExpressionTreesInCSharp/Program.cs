using ExpressionTreesInCSharp.EntityFramework;

namespace ExpressionTreesInCSharp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Create and Execute Expression Tree From Lambda Expression");
        var sum = ExpressionTrees.CreateExpressionTreeFromLambdaExpression();

        Console.WriteLine(sum.Compile()(1, 2));

        Console.WriteLine("Create and Execute Expression Tree From Expression Class API");
        var sumFromClass = ExpressionTrees.CreateExpressionTreeUsingExpressionTreeClass();
        Console.WriteLine(sumFromClass.Compile()(1, 2));

        Console.WriteLine("Inspecting EF Core Query:");
        var efCore = new EntityFrameworkSqlite();

        Console.WriteLine("Translated Query to List Users:");
        Console.WriteLine(efCore.GetUsersListQuery() + "\n");

        Console.WriteLine("Translated Query to Filter Users:");
        Console.WriteLine(efCore.GetWhereQuery());
    }
}
