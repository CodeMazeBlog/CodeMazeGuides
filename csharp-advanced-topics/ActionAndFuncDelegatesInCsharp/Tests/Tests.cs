
public class Tests
{
    [Fact]
    public void GivenActionDelegate_WhenAddActionDelegateIsCalled_ThenSumIsPrinted()
    {
        int expected = 8;
        int resultActionDelegate = 0;

        Action<int, int> addActionDelegate = (a, b) => Console.WriteLine(a + b);
        resultActionDelegate = addActionDelegate(3, 5);

        Program.addActionDelegate(3, 5);
        Assert.Equal(expected, resultActionDelegate);
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