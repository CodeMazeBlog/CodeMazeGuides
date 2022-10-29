using FuncAndActionDelegates;

namespace FuncAndActionDelegatesUnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WhenPassedTwoNums_ShouldReturnSum()
    {
        //Arrange
        var val1 = 1;
        var val2 = 2;
        ProcessDataWithFunc obj = new ProcessDataWithFunc();

        //Act
        var totalResult = obj.CalculateSumWithReturnVal(val1, val2);

        //Assert

        Assert.That(totalResult, Is.EqualTo(val1 + val2));
    }

    [Test]
    public void WhenPassedSumFunc_ShouldReturnSum()
    {
        //Arrange
        var val1 = 1;
        var val2 = 2;

        ProcessDataWithFunc obj = new ProcessDataWithFunc();

        //Act
        var totalResult = obj.GetDataWithFunc(obj.CalculateSumWithReturnVal, val1, val2);

        //Assert

        Assert.That(totalResult, Is.EqualTo(val1 + val2));
    }
}
