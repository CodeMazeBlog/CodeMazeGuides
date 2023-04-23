using ExpressionTreesInCSharp;
using System.Linq.Expressions;

namespace Tests;

public class ExpressionTreeTests
{
    [Fact]
    public void WhenCreateExpressionTreeFromLambdaExpression_ThenShouldContainTheExpectedValues()
    {
        var sumExpressionTree = ExpressionTrees.CreateExpressionTreeFromLambdaExpression();
        AssertExpressionTreeProperties(sumExpressionTree);
    }

    private static void AssertExpressionTreeProperties(Expression<Func<int, int, int>> sumExpressionTree)
    {
        // root node
        Assert.Equal(ExpressionType.Lambda, sumExpressionTree.NodeType);
        Assert.Equal("number1", sumExpressionTree.Parameters[0].Name);
        Assert.Equal("number2", sumExpressionTree.Parameters[1].Name);
        Assert.Equal("(number1 + number2)", sumExpressionTree.Body.ToString());
        Assert.Equal(typeof(Int32), sumExpressionTree.ReturnType);

        // root -> body node
        Assert.Equal(ExpressionType.Add, sumExpressionTree.Body.NodeType);

        BinaryExpression body = (BinaryExpression)sumExpressionTree.Body;

        // root -> body -> left node
        Assert.Equal(ExpressionType.Parameter, body.Left.NodeType);
        ParameterExpression leftParam = (ParameterExpression)body.Left;
        Assert.IsAssignableFrom<Expression>(leftParam);
        Assert.Equal("number1", leftParam.Name);
        Assert.Same(leftParam, sumExpressionTree.Parameters[0]);

        // root -> body -> right node
        Assert.Equal(ExpressionType.Parameter, body.Right.NodeType);
        ParameterExpression rightParam = (ParameterExpression)body.Right;
        Assert.IsAssignableFrom<Expression>(rightParam);
        Assert.Equal("number2", rightParam.Name);
        Assert.Same(rightParam, sumExpressionTree.Parameters[1]);
    }

    [Fact]
    public void WhenCreateExpressionTreeUsingExpressionTreeClass_ThenShouldContainTheExpectedValues()
    {
        var expressionTree = ExpressionTrees.CreateExpressionTreeUsingExpressionTreeClass();

        AssertExpressionTreeProperties(expressionTree);
    }

    [Fact]
    public void GivenASumLambdaExpression_WhenExecutedWithTwoNumbersAsParameters_ThenShouldReturnTheCorrectSum()
    {
        var sumLambda = ExpressionTrees.CreateLambdaExpression();

        var sum = sumLambda(1, 1);

        Assert.Equal(2, sum);
    }

    [Fact]
    public void GivenAnExpressionTree_WhenCompiled_ThenShouldExecuteAndReturnResult()
    {
        var expression = ExpressionTrees.CreateExpressionTreeFromLambdaExpression();

        var compiledSumLambdaExpression = ExpressionTrees.CompileExpressionTreeToLambdaExpression(expression);

        var sum = compiledSumLambdaExpression(1, 1);

        Assert.Equal(2, sum);
    }
}