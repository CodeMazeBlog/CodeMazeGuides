namespace Tests;

public class ActionUnitTest
{
    [Fact]
    public void GivenAVariableOfAction_WhenAssigningANamedMethodAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Action<string> log;

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            log = Console.WriteLine;
            log("hai");
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }

    [Fact]
    public void GivenAVariableOfAction_WhenAssigningAnAnonymousMethodAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Action<string> log;

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            log = delegate(string x)
            {
                Console.WriteLine(x);
            };

            log("hai");
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }

    [Fact]
    public void GivenAVariableOfAction_WhenAssigningALambdaExpressionAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Action<string> log;

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            log = x => Console.WriteLine(x);
            log("hai");
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }
    
    [Fact]
    public void GivenSomeActionDelegates_WhenCombiningThemAndInvoking_ThenNoExceptionThrown()
    {
        #region Arrange

        Action<string> logDb = msg => Console.WriteLine($"logging to DB: {msg}");
        Action<string> logApi = msg => Console.WriteLine($"logging to API: {msg}");

        #endregion

        #region Act

        var exception = Record.Exception(() =>
        {
            Action<string> transform = logDb + logApi;
            transform("hello");
        });

        #endregion

        #region Assert

        Assert.Null(exception);

        #endregion
    }
}