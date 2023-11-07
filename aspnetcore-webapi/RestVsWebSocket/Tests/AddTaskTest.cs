using Microsoft.AspNetCore.Mvc;
using RestVsWebSocket.Controllers;

namespace Tests
{
    public class AddTaskTest
    {
        [Fact]
        public void WhenTaskIsAdded_AddToListReturnOk()
        {
            // Arrange
            var taskController = new TaskController(); 
            var task = "Sample Task"; // Valid task data

            // Act
            var result = taskController.AddTask(task) as ObjectResult;

            // Assert
            Assert.NotNull(result); 
            Assert.Equal(200, result.StatusCode); 
            Assert.Equal("Task added successfully.", result.Value);
            Assert.Contains(task, taskController._tasks);
        }
    }
}