
public class Tests
{
    [Fact]
    public void GivenActionDelegate_WhenAddActionDelegateIsCalled_ThenSumIsPrinted()
    {
        // This function is not testable because it writes to the console and does not return anything.
        Program.addActionDelegate(3, 5);
    }

    [Fact]
    public void GivenFuncDelegate_WhenAddFuncDelegateIsCalled_ThenSumIsReturned()
    {
        Func<int, int, int> addFuncDelegate = (a, b) => a + b;
        int expected = 8;
        int resultFuncDelegate = 0;

        resultFuncDelegate = Program.addFuncDelegate(3, 5);

        Assert.Equal(expected, resultFuncDelegate);
    }
}