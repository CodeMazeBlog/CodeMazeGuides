using Microsoft.AspNetCore.Mvc;
using WorkingWithRestSharp.Controllers;
using WorkingWithRestSharp.DataTransferObject;
using Xunit;

namespace Test.WorkingWithRestSharp
{
    public class RestSharpCrudTestImplementation
    {
        [Fact]
        public async void GetUserList_WhenCalled_ReturnsUserLists()
        {
            // Arrange
            UsersController userController = new UsersController();
            // Act
            var okResult = await userController.GetUserList();
            var value = (okResult as OkObjectResult)?.Value as UserList;
            // Assert
            Assert.IsType<UserList>(value);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async void GetUser_WhenCalled_ReturnsSpecificUser()
        {
            // Arrange
            UsersController userController = new UsersController();
            // Act
            var okResult = await userController.GetUser("1");
            var value = (okResult as OkObjectResult)?.Value as UserDetails;
            // Assert
            Assert.IsType<UserDetails>(value);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async void AddUser_WhenCalled_ReturnsAddedUserJobDetails()
        {
            // Arrange
            UsersController userController = new UsersController();
            UserForCreation userForCreation = new UserForCreation()
            {
                Name = "Code Maze",
                Job = "Editor"
            };
            // Act
            var okResult = await userController.AddUser(userForCreation);
            var value = (okResult as ObjectResult)?.Value as UserCreationResponse;
            // Assert
            Assert.IsType<UserCreationResponse>(value);
            Assert.IsType<ObjectResult>(okResult);
        }

        [Fact]
        public async void UpdateUser_WhenCalled_ReturnsUpdateUserJobDetails()
        {
            // Arrange
            UsersController userController = new UsersController();
            UserForUpdate userForUpdate = new UserForUpdate()
            {
                Name = "Code Maze",
                Job = "Editor"
            };
            // Act
            var okResult = await userController.UpdateUser(userForUpdate, "1");
            var value = (okResult as OkObjectResult)?.Value as UserUpdateResponse;
            // Assert
            Assert.IsType<UserUpdateResponse>(value);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async void DeleteUser_WhenCalled_ReturnsUpdateUserJobDetails()
        {
            // Arrange
            UsersController userController = new UsersController();
            // Act
            var okResult = await userController.DeleteUser("1");
            // Assert
            Assert.IsType<NoContentResult>(okResult);
        }
    }
}