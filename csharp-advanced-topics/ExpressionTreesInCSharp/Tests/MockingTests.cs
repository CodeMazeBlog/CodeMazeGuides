using ExpressionTreesInCSharp.Mocking;

namespace Tests;
public class MockingTests
{
    [Fact]
    public void GivenAMockCalculator_WhenUsedAsDependency_ThenShouldReturnMockValues()
    {
        var calculatorMock = new Mock<ICalculator>();

        calculatorMock.Setup(x => x.Add(1, 2)).Returns(3);

        var calculatorService = new CalculatorService(calculatorMock.Object);

        var sum = calculatorService.AddTwoNumbers(1, 2);

        Assert.Equal(3, sum);
    }
}
