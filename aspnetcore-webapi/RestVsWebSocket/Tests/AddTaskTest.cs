using Microsoft.AspNetCore.Mvc;
using RestVsWebSocket.Controllers;

namespace Tests;

public class AddTaskTest
{
    [Fact]
    public void WhenTaskIsAdded_AddToListReturnsOk()
    {
        // Arrange
        var taskController = new TaskController(); 
        var task = "Sample Task";

        // Act
        var result = taskController.AddTask(task) as ObjectResult;

        // Assert
        Assert.NotNull(result); 
        Assert.Equal(200, result.StatusCode); 
        Assert.Equal("Task added successfully.", result.Value);
        Assert.Contains(task, taskController.Tasks);
    }
}