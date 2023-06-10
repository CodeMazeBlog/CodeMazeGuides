using ExpressionTreesInCSharp.DynamicMethods;

namespace Tests;
public class DynamicMethodTests
{
    [Fact]
    public void GivenAMathStatement_WhenConvertedToExpressionTree_ThenShouldReturnExecutableFunction()
    {
        var productFunc = DynamicMethodGenerator.GenerateExecutableFunctionFromMathStatement("=a*b");

        var product = productFunc(2, 5);

        Assert.Equal(10, product);
    }
}
