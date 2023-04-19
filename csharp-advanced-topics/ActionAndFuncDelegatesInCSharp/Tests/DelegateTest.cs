using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Text;
using Xunit;

namespace Tests;

public class DelegateTest
{
    static readonly StringWriter bufferWriter = new StringWriter();

    public DelegateTest()
    {
        StringBuilder sb = bufferWriter.GetStringBuilder();
        sb.Remove(0, sb.Length);

        Console.SetOut(bufferWriter);
    }

    [Theory]
    [InlineData(10, 20, "Sum of 10 and 20 is 30")]
    public void WhenSumActionIsDefined_ThenWriteTheSum(int operator1, int operator2, string expectedOutput)
    {
        Action<int, int> WriteSumOfDelegate = (operator1, operator2) =>
        {
            Console.Write("Sum of {0} and {1} is {2}", operator1, operator2, operator1 + operator2);
        };
        WriteSumOfDelegate(operator1, operator2);


        string bufferOutput = bufferWriter?.ToString() ?? string.Empty;
        Assert.Equal(expectedOutput, bufferOutput);
    }

    [Fact]
    public void WhenActionDelegateIsDefined_ThenWriteHelloWorld()
    {
        Action helloWorldDelegate = () => Console.Write("Hello, World!");
        helloWorldDelegate();

        string bufferOutput = bufferWriter?.ToString() ?? string.Empty;
        Assert.Equal("Hello, World!", bufferOutput);
    }

    [Theory]
    [InlineData(2, 4)]
    public void WhenFuncDoubleIsDefined_ThenReturnDoubleOfInput(int operator1, int expectedOutput)
    {
        Func<int, int> DoubleItDelegate = (operator1) =>
        {
            return operator1 * 2;
        };
        var result = DoubleItDelegate(operator1);

        Console.WriteLine("Func Double result {0}", result);
        Assert.Equal(expectedOutput, result);
    }
}
