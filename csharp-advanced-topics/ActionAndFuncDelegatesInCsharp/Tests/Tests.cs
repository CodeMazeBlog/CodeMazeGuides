
public class Tests
{
    [Fact]
    public void GivenActionDelegate_WhenAddActionDelegateIsCalled_ThenSumIsPrinted()
    {
        var sw = new StringWriter();
        Console.SetOut(sw);

        Program.AddActionDelegate(3, 5);

        var expectedOutput = "Sum Action Delegate: 8" + Environment.NewLine;
        Assert.Equal(expectedOutput, sw.ToString());
    }

    [Fact]
    public void GivenFuncDelegate_WhenAddFuncDelegateIsCalled_ThenSumIsReturned()
    {
        var expected = 8;
        var resultFuncDelegate = Program.AddFuncDelegate(3, 5);

        Assert.Equal(expected, resultFuncDelegate);
    }
}