using System.Text;
using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests;

public class MyMathOperationsUnitTests
{
    [Theory]
    [InlineData(10, 20)]
    [InlineData(20, 30)]
    [InlineData(-10, 10)]
    [InlineData(0, 10)]
    [InlineData(0, 0)]
    public void GivenTwoNumbers_WhenAdding_ThenComputesSum(int a, int b)
    {
        var result = MyMathOperations.AddTwoNumbers(a, b);

        Assert.Equal((double) a + b, result);
    }

    [Theory]
    [InlineData(10, 20)]
    [InlineData(20, 30)]
    [InlineData(-10, 10)]
    [InlineData(0, 10)]
    [InlineData(0, 0)]
    public void GivenTwoNumbers_WhenSubtracting_ThenComputesDifference(int a, int b)
    {
        var result = MyMathOperations.SubtractTwoNumbers(a, b);

        Assert.Equal((double) a - b, result);
    }

    [Theory]
    [InlineData(10, 20)]
    [InlineData(20, 30)]
    [InlineData(-10, 10)]
    [InlineData(0, 10)]
    [InlineData(0, 0)]
    public void GivenTwoNumbers_WhenDividing_ThenComputesQuotient(double a, int b)
    {
        var result = MyMathOperations.DivideTwoNumbers(a, b);

        Assert.Equal(a / b, result);
    }

    [Fact]
    public void GivenOutputToWrite_WhenWritten_ThenWritesExpectedOutput()
    {
        const string test = """
            This is a test string that verifies that our string output is working as we expect.
            There is nothing to worry about. We are just defining a string that we can use to verify
            that everything is working just as we expect it to.
            """;
        try
        {
            // Simulate Console.WriteLine
            var expected = new StringBuilder(test);
            expected.AppendLine();

            using var sw = new StringWriter();
            Console.SetOut(sw);
            MyOutputOperations.WriteOutput(test);

            Assert.Equal(expected.ToString(), sw.ToString());
        }
        finally
        {
            if (Console.IsOutputRedirected)
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true});
        }
    }
}