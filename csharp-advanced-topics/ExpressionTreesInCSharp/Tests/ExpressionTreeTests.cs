using ExpressionTreesInCSharp;
using System.Linq.Expressions;

namespace Tests;

public class ExpressionTreeTests
{
    [Fact]
    public void GivenALambdaExpression_WhenConvertedToExpressionTree_ShouldContainTheExpectedValues()
    {
        var sumExpressionTree = ExpressionTrees.CreateExpressionTreeFromLambdaExpression();
        Assert.Equal(ExpressionType.Lambda, sumExpressionTree.NodeType);
        Assert.Equal("number1", sumExpressionTree.Parameters[0].Name);
        Assert.Equal("number2", sumExpressionTree.Parameters[1].Name);
        Assert.Equal("(number1 + number2)", sumExpressionTree.Body.ToString());
        Assert.Equal(typeof(Int32), sumExpressionTree.ReturnType);

        Assert.Equal(ExpressionType.Add, sumExpressionTree.Body.NodeType);

        BinaryExpression body = (BinaryExpression)sumExpressionTree.Body;

        Assert.Equal(ExpressionType.Parameter, body.Left.NodeType);
        ParameterExpression leftParam = (ParameterExpression)body.Left;
        Assert.IsAssignableFrom<Expression>(leftParam);
        Assert.Equal("number1", leftParam.Name);
        Assert.Same(leftParam, sumExpressionTree.Parameters[0]);

        Assert.Equal(ExpressionType.Parameter, body.Right.NodeType);
        ParameterExpression rightParam = (ParameterExpression)body.Right;
        Assert.IsAssignableFrom<Expression>(rightParam);
        Assert.Equal("number2", rightParam.Name);
        Assert.Same(rightParam, sumExpressionTree.Parameters[1]);
    }

    [Fact]
    public void GivenAnExpressionTreeFromAPI_WhenInspected_ShouldContainTheExpectedValues()
    {
        var expressionTree = ExpressionTrees.CreateExpressionTreeUsingExpressionTreeClass();

        BinaryExpression body = (BinaryExpression)expressionTree.Body;

        Assert.Equal(ExpressionType.Lambda, expressionTree.NodeType);
        Assert.Equal(typeof(Int32), expressionTree.ReturnType);
        Assert.Equal(ExpressionType.Add, body.NodeType);

        ParameterExpression leftParam = (ParameterExpression)body.Left;
        Assert.IsAssignableFrom<Expression>(leftParam);
        Assert.Same(leftParam, expressionTree.Parameters[0]);
        Assert.Equal(ExpressionType.Parameter, leftParam.NodeType);
        Assert.Equal("number1", leftParam.Name);

        ParameterExpression rightParam = (ParameterExpression)body.Right;
        Assert.IsAssignableFrom<Expression>(rightParam);
        Assert.Same(rightParam, expressionTree.Parameters[1]);
        Assert.Equal(ExpressionType.Parameter, rightParam.NodeType);
        Assert.Equal("number2", rightParam.Name);
    }

    [Fact]
    public void GivenALambdaExpression_WhenInvoked_ShouldReturnCorrectValue()
    {
        var sumLambda = ExpressionTrees.CreateLambdaExpression();

        var sum = sumLambda(1, 1);

        Assert.Equal(2, sum);
    }

    [Fact]
    public void GivenAnExpressionTree_WhenCompiled_ShouldExecuteAndReturnResult()
    {
        var compiledSumLambdaExpression = ExpressionTrees.CompileExpressionTreeToLambdaExpression();

        var sum = compiledSumLambdaExpression(1, 1);

        Assert.Equal(2, sum);
    }
}