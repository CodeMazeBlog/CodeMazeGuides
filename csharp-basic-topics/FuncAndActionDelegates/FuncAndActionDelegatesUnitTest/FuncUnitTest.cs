using FuncAndActionDelegates;

namespace FuncAndActionDelegatesUnitTest;

public class Tests
{
    ProcessDataWithFunc _obj;

    [SetUp]
    public void Setup()
    {
        _obj = new ProcessDataWithFunc();
    }

    [Test]
    public void WhenPassedTwoNums_ThenShouldReturnSum()
    {
        //Arrange
        var val1 = 1;
        var val2 = 2;

        //Act
        var totalResult = _obj.CalculateSumWithReturnVal(val1, val2);

        //Assert

        Assert.That(totalResult, Is.EqualTo(val1 + val2));
    }

    [Test]
    public void WhenPassedSumFunc_ThenShouldReturnSum()
    {
        //Arrange
        var val1 = 1;
        var val2 = 2;

        //Act
        var totalResult = _obj.GetDataWithFunc(_obj.CalculateSumWithReturnVal, val1, val2);

        //Assert

        Assert.That(totalResult, Is.EqualTo(val1 + val2));
    }
}
