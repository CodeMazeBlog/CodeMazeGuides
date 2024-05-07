using ExceptionlessClient.Controllers;

namespace Tests;

public class ValuesControllerTest
{
    [Fact]
    public void GivenGetEndpoint_WhenInvoked_ThenThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Throws<Exception>(controller.Get);
    }

    [Fact]
    public void GivenManualExceptionEndpoint_WhenInvoked_ThenDoesnNotThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Null(Record.Exception(controller.ManualException));
    }

    [Fact]
    public void GivenLogsEndpoint_WhenInvoked_ThenDoesnNotThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Null(Record.Exception(controller.Logs));
    }

    [Fact]
    public void GivenFeatureEndpoint_WhenInvoked_ThenDoesnNotThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Null(Record.Exception(controller.Feature));
    }

    [Fact]
    public void GivenCustomStackEndpoint_WhenInvoked_ThenDoesnNotThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Null(Record.Exception(controller.CustomStack));
    }

    [Fact]
    public void GivenDataExclusionEndpoint_WhenInvoked_ThenDoesnNotThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Null(Record.Exception(controller.DataExclusion));
    }

    [Fact]
    public void GivenLogLevelEndpoint_WhenInvoked_ThenDoesnNotThrowException()
    {
        // Arrange
        var controller = new ValuesController();

        // Act & Assert
        Assert.Null(Record.Exception(controller.LogLevel));
    }
}