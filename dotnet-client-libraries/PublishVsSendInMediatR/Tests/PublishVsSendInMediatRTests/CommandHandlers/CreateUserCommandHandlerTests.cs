using PublishVsSendInMediatR.CommandHandlers;
using PublishVsSendInMediatR.Repositories;
using PublishVsSendInMediatR.Commands;
using PublishVsSendInMediatR.Models;
using Moq;

namespace PublishVsSendInMediatRTests.CommandHandlers
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task WhenCreateANewUserHandle_ThenReturnValidUserId()
        {
            //Arrange
            var userId = new Random().Next();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock
                .Setup(x => x.CreateUserAsync(It.IsAny<User>()))
                .ReturnsAsync(userId);

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object);
            var request = new CreateUserCommand { Email = "sample@email.com", UserName = "sample" };

            // Act
            var result = await createUserCommandHandler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.Equal(userId, result);
        }
    }
}
