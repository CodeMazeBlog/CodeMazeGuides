namespace LogLevelsWithSerilogTests;

[TestClass]
public class LogLevelsWithSerilogTests
{
    private HomeController? _homeController;
    private Mock<ILogger<HomeController>>? _loggerMock;
    private string _message = string.Empty;

    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<HomeController>>();
        _homeController = new HomeController(_loggerMock.Object);

        var fixture = new Fixture();
        _message = fixture.Create<string>();
    }

    [TestMethod]
    public void WhenLogRouteCalledWithDebug_ThenDebugLogMustBeCalled()
    {
        TestGenerateLog(Serilog.Events.LogEventLevel.Debug);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithInformation_ThenInformationLogMustBeCalled()
    {
        TestGenerateLog(Serilog.Events.LogEventLevel.Information);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithWarning_ThenWarningLogMustBeCalled()
    {
        TestGenerateLog(Serilog.Events.LogEventLevel.Warning);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithError_ThenErrorLogMustBeCalled()
    {
        TestGenerateLog(Serilog.Events.LogEventLevel.Error);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithFatal_ThenFatalLogMustBeCalled()
    {
        TestGenerateLog(Serilog.Events.LogEventLevel.Fatal);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithInvalidLogLevel_ThenInformationLogMustBeCalled()
    {
        var logTypeInvalid = -5;

        _homeController?.GenerateLog(_message, logTypeInvalid);

        _loggerMock?.Verify(x => x.Log(LogLevel.Information,
             It.IsAny<EventId>(),
             It.Is<It.IsAnyType>((v, _) => v!.ToString()!.Equals($"InvalidLogType : {_message}", StringComparison.Ordinal)),
             It.IsAny<Exception>(),
             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }

    private void TestGenerateLog(Serilog.Events.LogEventLevel logLevel)
    {
        var logType = (int)logLevel;
        var logTypeName = logLevel.ToString();

        _homeController?.GenerateLog(_message, logType);

        _loggerMock?.Verify(x => x.Log((LogLevel)logLevel,
              It.IsAny<EventId>(),
              It.Is<It.IsAnyType>((v, _) => v!.ToString()!.Equals($"{logTypeName} Log : {_message}", StringComparison.Ordinal)),
              It.IsAny<Exception>(),
              It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }
}