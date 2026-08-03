using ExceptionlessClient.Controllers;

namespace Tests;

public class ValuesControllerTest
{
    readonly ValuesController controller;

    public ValuesControllerTest()
    {
        // Arrange
        controller = new ValuesController();
    }

    [Fact]
    public void GivenGetEndpoint_WhenInvoked_ThenThrowException()
    {
        // Act & Assert
        Assert.Throws<Exception>(controller.Get);
    }

    [Fact]
    public void GivenManualExceptionEndpoint_WhenInvoked_ThenDoesNotThrowException()
    {
        // Act & Assert
        Assert.Null(Record.Exception(controller.ManualException));
    }

    [Fact]
    public void GivenLogsEndpoint_WhenInvoked_ThenDoesNotThrowException()
    {
        // Act & Assert
        Assert.Null(Record.Exception(controller.Logs));
    }

    [Fact]
    public void GivenFeatureEndpoint_WhenInvoked_ThenDoesNotThrowException()
    {
        // Act & Assert
        Assert.Null(Record.Exception(controller.Feature));
    }

    [Fact]
    public void GivenCustomStackEndpoint_WhenInvoked_ThenDoesNotThrowException()
    {
        // Act & Assert
        Assert.Null(Record.Exception(controller.CustomStack));
    }

    [Fact]
    public void GivenDataExclusionEndpoint_WhenInvoked_ThenDoesNotThrowException()
    {
        // Act & Assert
        Assert.Null(Record.Exception(controller.DataExclusion));
    }

    [Fact]
    public void GivenLogLevelEndpoint_WhenInvoked_ThenDoesNotThrowException()
    {
        // Act & Assert
        Assert.Null(Record.Exception(controller.LogLevel));
    }
}