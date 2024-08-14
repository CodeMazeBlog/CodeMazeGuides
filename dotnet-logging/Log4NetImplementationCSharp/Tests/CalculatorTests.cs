using log4net.Appender;
using log4net.Config;
using LoggingInCSharp;

namespace Tests;

public class CalculatorTests
{
    private MemoryAppender memoryAppender;

    public CalculatorTests()
    {
        memoryAppender = new MemoryAppender();
        BasicConfigurator.Configure(memoryAppender);
    }

    [Fact]
    public void GivenTwoPositiveNumbers_WhenAddCalled_ThenLogCorrectlyAndReturnSum()
    {
        Calculator.Add(5, 3);

        var events = memoryAppender.GetEvents();

        Assert.Equal(2, events.Length);
        Assert.Contains("Adding 5 and 3", events[0].RenderedMessage);
        Assert.Contains("Result of 5 + 3 = 8", events[1].RenderedMessage);
    }

    [Fact]
    public void GivenNumbersResultingInNegative_WhenSubtractCalled_ThenLogWarningAndReturnDifference()
    {
        Calculator.Subtract(5, 10);

        var events = memoryAppender.GetEvents();

        Assert.Equal(3, events.Length);
        Assert.Contains("Subtracting 10 from 5", events[0].RenderedMessage);
        Assert.Contains("Subtraction may result in a negative number: 5 - 10", events[1].RenderedMessage);
        Assert.Contains("Result of 5 - 10 = -5", events[2].RenderedMessage);
    }

    [Fact]
    public void GivenTwoPositiveNumbers_WhenMultiplyCalled_ThenLogCorrectlyAndReturnProduct()
    {
        Calculator.Multiply(4, 6);

        var events = memoryAppender.GetEvents();

        Assert.Equal(2, events.Length);
        Assert.Contains("Multiplying 4 and 6", events[0].RenderedMessage);
        Assert.Contains("Result of 4 * 6 = 24", events[1].RenderedMessage);
    }

    [Fact]
    public void GivenZeroAsOperand_WhenMultiplyCalled_ThenLogWarningAndReturnZero()
    {
        Calculator.Multiply(0, 5);

        var events = memoryAppender.GetEvents();

        Assert.Equal(3, events.Length);
        Assert.Contains("Multiplying 0 and 5", events[0].RenderedMessage);
        Assert.Contains("Multiplication resulted in zero: 0 * 5", events[1].RenderedMessage);
        Assert.Contains("Result of 0 * 5 = 0", events[2].RenderedMessage);
    }

    [Fact]
    public void GivenZeroAsDivisor_WhenDivideCalled_ThenLogErrorAndThrowDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5, 0));

        var events = memoryAppender.GetEvents();
        
        Assert.Equal(2, events.Length);
        Assert.Contains("Dividing 5 by 0", events[0].RenderedMessage);
        Assert.Contains("Division by zero attempted", events[1].RenderedMessage);
    }
}
