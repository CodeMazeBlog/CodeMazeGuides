using AutoFixture;
using LogLevelsWithSerilog.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace LogLevelsWithSerilogTests;

[TestClass]
public class LogLevelsWithSerilogTests
{
    private HomeController? _homeController;
    private Mock<ILogger<HomeController>>? _loggerMock;
    private IFixture? _fixture;

    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
        _loggerMock = new Mock<ILogger<HomeController>>();
        _homeController = new HomeController(_loggerMock.Object);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithDebug_ThenDebugLogMustBeCalled()
    {
        var message = _fixture.Create<string>();
        var logType = (int)LogLevel.Debug;

        _homeController?.GenerateLog(message, logType);

        _loggerMock?.Verify(x => x.Log(LogLevel.Debug,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => true),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithInformation_ThenInformationLogMustBeCalled()
    {
        var message = _fixture.Create<string>();
        var logType = (int)LogLevel.Information;

        _homeController?.GenerateLog(message, logType);

        _loggerMock?.Verify(x => x.Log(LogLevel.Information,
             It.IsAny<EventId>(),
             It.Is<It.IsAnyType>((v, t) => true),
             It.IsAny<Exception>(),
             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithWarning_ThenWarningLogMustBeCalled()
    {
        var message = _fixture.Create<string>();
        var logType = (int)LogLevel.Warning;

        _homeController?.GenerateLog(message, logType);

        _loggerMock?.Verify(x => x.Log(LogLevel.Warning,
             It.IsAny<EventId>(),
             It.Is<It.IsAnyType>((v, t) => true),
             It.IsAny<Exception>(),
             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithError_ThenErrorLogMustBeCalled()
    {
        var message = _fixture.Create<string>();
        var logType = (int)LogLevel.Error;

        _homeController?.GenerateLog(message, logType);

        _loggerMock?.Verify(x => x.Log(LogLevel.Error,
             It.IsAny<EventId>(),
             It.Is<It.IsAnyType>((v, t) => true),
             It.IsAny<Exception>(),
             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithFatal_ThenFatalLogMustBeCalled()
    {
        var message = _fixture.Create<string>();
        var logType = (int)LogLevel.Critical;

        _homeController?.GenerateLog(message, logType);

        _loggerMock?.Verify(x => x.Log(LogLevel.Critical,
             It.IsAny<EventId>(),
             It.Is<It.IsAnyType>((v, t) => true),
             It.IsAny<Exception>(),
             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }

    [TestMethod]
    public void WhenLogRouteCalledWithInvalidLogLevel_ThenInformationLogMustBeCalled()
    {
        var message = _fixture.Create<string>();
        var logType = -5;

        _homeController?.GenerateLog(message, logType);

        _loggerMock?.Verify(x => x.Log(LogLevel.Information,
             It.IsAny<EventId>(),
             It.Is<It.IsAnyType>((v, t) => true),
             It.IsAny<Exception>(),
             It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Once);
    }
}