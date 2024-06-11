using HowToUseFakeLogger;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Testing;

namespace FakeLoggerTests;

[TestClass]
public class FileManagerTests
{
    private IFixture _fixture;
    private Mock<ILogger> _loggerMock;
    private FileManager _fileManager;

    private FakeLogger<FileManager> _fakeLogger;
    private FileManager _fileManager2;

    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
        _loggerMock = new Mock<ILogger>();
        _fileManager = new FileManager(_loggerMock.Object);

        _fakeLogger = new FakeLogger<FileManager>();
        _fileManager2 = new FileManager(_fakeLogger);
    }

    [TestMethod]
    public void WhenReadFileCalled_ForARandomString_ThenInvalidExtensionLogTestMustPass()
    {
        var fileName = _fixture.Create<string>();

        var result = _fileManager.ReadFile(fileName);

        Assert.AreEqual(string.Empty, result);
        _loggerMock.Verify(logger => logger.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Invalid extension")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once());
    }

    [TestMethod]
    public void WhenReadFileCalled_WithFakeLogger_ForARandomString_ThenInvalidExtensionLogTestMustPass()
    {
        var fileName = _fixture.Create<string>();

        var result = _fileManager2.ReadFile(fileName);

        Assert.AreEqual(string.Empty, result);
        Assert.IsNotNull(_fakeLogger.Collector.LatestRecord);
        Assert.AreEqual(1, _fakeLogger.Collector.Count);
        Assert.AreEqual(LogLevel.Warning, _fakeLogger.Collector.LatestRecord.Level);
        Assert.AreSame("Invalid extension", _fakeLogger.Collector.LatestRecord.Message);
    }

    [TestMethod]
    public void WhenReadFileCalled_WithFakeLogger_ForValidFilename_ThenErrorOccurredLogTestMustPass()
    {
        var fileName = "test-file.pdf";

        var result = _fileManager2.ReadFile(fileName);

        Assert.AreEqual(string.Empty, result);
        Assert.IsNotNull(_fakeLogger.Collector.LatestRecord);
        Assert.AreEqual(2, _fakeLogger.Collector.Count);
        Assert.AreEqual(LogLevel.Error, _fakeLogger.Collector.LatestRecord.Level);
        Assert.AreEqual(LogLevel.Information, _fakeLogger.Collector.GetSnapshot()[0].Level);
        Assert.AreSame("Error occurred", _fakeLogger.Collector.LatestRecord.Message);
    }

    [TestMethod]
    public void WhenReadFileCalled_WithFakeLoggerOptions_ForValidFilename_ThenErrorOccurredLogTestMustPass()
    {
        var options = new FakeLogCollectorOptions()
        {
            CollectRecordsForDisabledLogLevels = true,
            OutputSink = Console.WriteLine
        };
        options.FilteredLevels.Add(LogLevel.Error);

        var collection = FakeLogCollector.Create(options);
        var fakeLogger = new FakeLogger<FileManager>(collection);
        var fileManager = new FileManager(fakeLogger);

        var fileName = "test-file.pdf";

        var result = fileManager.ReadFile(fileName);

        Assert.AreEqual(string.Empty, result);
        Assert.IsNotNull(fakeLogger.Collector.LatestRecord);
        Assert.AreEqual(1, fakeLogger.Collector.Count);
        Assert.AreEqual(LogLevel.Error, fakeLogger.Collector.LatestRecord.Level);
        Assert.AreSame("Error occurred", fakeLogger.Collector.LatestRecord.Message);
    }
}