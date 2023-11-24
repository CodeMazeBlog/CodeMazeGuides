using Moq;
using Quartz;
using Quartz.NET;

namespace Tests;

public class BackgroundJobTests
{
    private readonly Mock<IJobExecutionContext> _jobExecutionContextMock;
    private readonly BackgroundJob _backgroundJob = new BackgroundJob();

    public BackgroundJobTests()
    {
        _jobExecutionContextMock= new Mock<IJobExecutionContext>();
    }

    [Fact]
    public async Task GivenAValidJobDataMap_WhenUsingJobDataMapForOuputIsTrue_ThenUsesJobDataMapConsoleOutput()
    {
        const string consoleOutput = "test console output";
        var expectedOutput = $"{consoleOutput}{Environment.NewLine}";
        // Arrange
        var jobDataMap = new JobDataMap
        {
            { "UseJobDataMapConsoleOutput", true },
            { "ConsoleOutput", consoleOutput }
        };
        _jobExecutionContextMock.SetupGet(j => j.MergedJobDataMap).Returns(jobDataMap);
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await _backgroundJob.Execute(_jobExecutionContextMock.Object);

        // Assert
        Assert.Equal(expectedOutput, stringWriter.ToString());
    }

    [Fact]
    public async Task GivenAValidJobDataMap_WhenUsingJobDataMapForOuputIsFalse_ThenUsesDefaultConsoleOutput()
    {
        const string defaultOutput = "Executing background job without JobDataMap";
        var expectedOutput = $"{defaultOutput}{Environment.NewLine}";
        // Arrange
        var jobDataMap = new JobDataMap
        {
            { "UseJobDataMapConsoleOutput", false }
        };
        _jobExecutionContextMock.SetupGet(j => j.MergedJobDataMap).Returns(jobDataMap);
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        await _backgroundJob.Execute(_jobExecutionContextMock.Object);

        // Assert
        Assert.Equal(expectedOutput, stringWriter.ToString());
    }
}