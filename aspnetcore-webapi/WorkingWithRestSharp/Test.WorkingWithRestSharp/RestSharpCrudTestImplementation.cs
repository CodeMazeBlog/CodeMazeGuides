
using WorkingWithRestSharp;
using WorkingWithRestSharp.Controllers;

using Xunit;

namespace Test.WorkingWithRestSharp
{
    public class RestSharpCrudTestImplementation
    {
        [Fact]
        public async void GetUserList_WhenCalled_ReturnsUserLists()
        {
            // Arrange
            UserController userController = new UserController();
            // Act
            var okResult = await userController.GetUserList();
            // Assert
            Assert.IsType<UserDetails>(okResult);
        }

        [Fact]
        public async void GetUserDetailsById_WhenCalled_ReturnsSpecificUser()
        {
            // Arrange
            UserController userController = new UserController();
            // Act
            var okResult = await userController.GetUserDetailsById("1");
            // Assert
            Assert.IsType<SingleUserDetails>(okResult);
        }

        [Fact]
        public async void AddNewUserAndJob_WhenCalled_ReturnsAddedUserJobDetails()
        {
            // Arrange
            UserController userController = new UserController();
            UserJobDetailsRequest userJobDetailsRequest = new UserJobDetailsRequest
            {
                Name = "Code Maze",
                Job = "Editor"
            };
            // Act
            var okResult = await userController.AddNewUserAndJob(userJobDetailsRequest);
            // Assert
            Assert.IsType<UserJobDetails>(okResult);
        }

        [Fact]
        public async void UpdateUserAndJob_WhenCalled_ReturnsUpdateUserJobDetails()
        {
            // Arrange
            UserController userController = new UserController();
            UpdateUserJobDetailsRequest updateUserJobDetailsRequest = new UpdateUserJobDetailsRequest
            {
                Id = "1",
                Name = "Code Maze",
                Job = "Editor"
            };
            // Act
            var okResult = await userController.UpdateUserAndJob(updateUserJobDetailsRequest);
            // Assert
            Assert.IsType<UpdateUserJobDetails>(okResult);
        }

        [Fact]
        public async void DeleteUser_WhenCalled_ReturnsUpdateUserJobDetails()
        {
            // Arrange
            UserController userController = new UserController();
            // Act
            var okResult = await userController.DeleteUser("1");
            // Assert
            Assert.IsType<DeleteResponse>(okResult);
        }
    }
}