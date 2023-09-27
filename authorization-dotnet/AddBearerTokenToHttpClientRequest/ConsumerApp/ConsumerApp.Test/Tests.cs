using ConsumerApp.Application.cs;
using ConsumerApp.Domain.Interfaces;
using ConsumerApp.Domain.Model;
using Moq;

namespace ConsumerApp.Test
{
    public class Tests
    {
        private readonly ProgramApplication _programApplication;
        public Tests()
        {
            _programApplication = InstanciateApplication();
        }
        
        [Fact]
        public async Task GivenAnApplication_WhenWaitingForAllUsers_ThenReturnALlUsers()
        {
            var users = await _programApplication.GetAllUsers();

            Assert.True(users.Any());
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public async Task GivenAnApplication_WhenWaitingForASpecificUser_ThenReturnOneUser()
        {
            var users = await _programApplication.GetUserById(1);

            Assert.Equal("John", users.FirstName);
            Assert.Equal("Doe", users.LastName);
            Assert.Equal("12345", users.Password);
            Assert.Equal("code@maze.com", users.Email);
        }

        private ProgramApplication InstanciateApplication()
        {
            Mock<IUserApiRepository> userApiRepositoryMock = CreateUserApiRepositoryMock();
            Mock<ILoginApiRepository> loginApiRepositoryMock = CreateLoginApiRepositoryMock();

            return new ProgramApplication(userApiRepositoryMock.Object, loginApiRepositoryMock.Object);
        }

        private static Mock<ILoginApiRepository> CreateLoginApiRepositoryMock()
        {
            var loginApiRepositoryMock = new Mock<ILoginApiRepository>();

            loginApiRepositoryMock.Setup(x => x.AuthenticateAsync())
                .ReturnsAsync(new AccessToken());

            return loginApiRepositoryMock;
        }

        private static Mock<IUserApiRepository> CreateUserApiRepositoryMock()
        {
            var userApiRepositoryMock = new Mock<IUserApiRepository>();

            userApiRepositoryMock.Setup(x => x.GetUsersAsync())
                .ReturnsAsync(new List<UserModel> 
                { 
                    new(), 
                    new() 
                });

            userApiRepositoryMock.Setup(x => x.GetUserAsync(It.IsAny<int>()))
                .ReturnsAsync(new UserModel 
                { 
                    FirstName = "John", 
                    LastName = "Doe", 
                    Password = "12345", 
                    Email = "code@maze.com" 
                });

            return userApiRepositoryMock;
        }
    }
}