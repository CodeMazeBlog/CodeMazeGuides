namespace FuncAndActionCSharpTests
{
    public class FuncAndActionCSharpTests : IClassFixture<StringWriterFixture>
    {
        private const string _logMessage = "The operation finished in 1.1 sec";
        StringWriterFixture _fixture;

        public FuncAndActionCSharpTests(StringWriterFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GivenFuncDelegate_WhenPerformsFiltration_ThenFilterEvenNumbers()
        {
            // Arrange
            var func = new FuncDelegate();
            var numbers = new List<int> { 42, 18, 7, 31, 55, 89, 23, 14, 68, 37, 91, 12, 63, 29, 50, 5, 18, 7, 31, 55, 89, 23, 14, 68, 37, 91, 12, 63, 29, 50, 5, 82 };

            // Act
            var result = func.PerformFiltration(numbers);

            // Assert
            Assert.Equal(12, result.Count());
            Assert.Equal(new List<int> { 42, 18, 14, 68, 12, 50, 18, 14, 68, 12, 50, 82 }, result);
        }

        [Fact]
        public void GivenActionDelegate_WhenLogsMessageUsingLogger_ThenInformationType()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var loggerSubs = Substitute.For<Action<string>>();
            var message = "The request was intercepted by filtering middleware.";

            // Act
            actionDelegate.Information(loggerSubs, message);

            // Assert
            loggerSubs.Received(1).Invoke(message);
        }

        [Fact]
        public void GivenActionDelegate_WhenLogsMessageUsingLogger_ThenWarningType()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var loggerSubs = Substitute.For<Action>();

            // Act
            actionDelegate.Warning(loggerSubs);

            // Assert
            loggerSubs.Received(1).Invoke();
        }

        [Fact]
        public void GivenActionDelegate_WhenLogsMessageUsingLogger_ThenErrorType()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var loggerSubs = Substitute.For<Action<string>>();
            var message = "Invalid request error";


            Console.SetOut(_fixture.Writer);

            // Act
            actionDelegate.Error(message);

            // Assert
            loggerSubs.Received(1);
        }

        [Fact]
        public void GivenDelegate_WhenInformationLevelConsoleLoggerInstantiated_ThenPrintsMessageToConsole()
        {
            // Arrange
            var delegateIntroduction = new Delegate();

            var consoleLogger = Substitute.ForPartsOf<Delegate>();
            consoleLogger.When(
                x => x.InformationLevelConsoleLogger(
                    Arg.Any<string>()))
                .CallBase();

            // Act
            consoleLogger.InformationLevelConsoleLogger(_logMessage);

            // Assert
            consoleLogger.Received()
                .InformationLevelConsoleLogger(_logMessage);
        }

        [Fact]
        public void GivenDelegate_WhenInvokeSimpleDelegate_ThenInvokesLogger()
        {
            // Arrange
            var delegateIntroduction = new Delegate();

            var consoleLogger = Substitute.ForPartsOf<Delegate>();
            consoleLogger.When(
                x => x.InformationLevelConsoleLogger(
                    Arg.Any<string>()))
                .CallBase();

            // Act
            Console.SetOut(_fixture.Writer);

            consoleLogger.InvokeSimpleDelegate();
            var expectedOutput = $"Additional information: {_logMessage}\r\nAdditional information: {_logMessage}\r\n";
          
            // Assert
            Assert.Equal(expectedOutput, _fixture.Writer.ToString());
        }
    }
}