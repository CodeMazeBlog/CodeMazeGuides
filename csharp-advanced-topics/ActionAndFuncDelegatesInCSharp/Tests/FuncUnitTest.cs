namespace Tests;

public class FuncUnitTest
{
    [Fact]
    public void GivenAVariableOfFunc_WhenAssigningANamedMethodAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Func<double, double> findRoot;

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            findRoot = Math.Sqrt;
            findRoot(25);
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }

    [Fact]
    public void GivenAVariableOfFunc_WhenAssigningAnAnonymousMethodAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Func<double, double> findRoot;

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            findRoot = delegate(double x) { return Math.Sqrt(x); };

            findRoot(25);
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }

    [Fact]
    public void GivenAVariableOfFunc_WhenAssigningALambdaExpressionAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Func<double, double> findRoot;

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            findRoot = x => Math.Sqrt(x);
            findRoot(25);
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }
    
    [Fact]
    public void GivenSomeFuncDelegates_WhenCombiningThemAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Func<string, string> toUpper = str => str.ToUpper();
        Func<string, string> toLower = str => str.ToLower();

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            Func<string, string> transform = toUpper + toLower;
            transform("hello");
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }
}