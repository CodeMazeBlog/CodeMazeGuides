using Moq;
using PublishVsSendInMediatR.EventHandlers;
using PublishVsSendInMediatR.Events;
using PublishVsSendInMediatR.Models;
using PublishVsSendInMediatR.Repositories;
using PublishVsSendInMediatR.Services;

namespace PublishVsSendInMediatRTests.EventHandlers
{
    public class UserCreatedEventHandlerTests
    {
        [Fact]
        public async Task WhenHandleUserCreatedEvent_ThenVerifyUserIdAndSendNotification()
        {
            //Arrange
            var userId = new Random().Next();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock
                .Setup(x => x.GetAdminUserAsync())
                .ReturnsAsync(new User { UserId = 1 });

            var notificationServiceMock = new Mock<INotificationService>();
            var userCreatedEventHandler = new UserCreatedEventHandler(userRepositoryMock.Object, notificationServiceMock.Object);
            var request = new UserCreatedEvent { UserId = 1, UserName = "sampleUser" };

            // Act
            await userCreatedEventHandler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            userRepositoryMock.Verify(x => x.GetAdminUserAsync(), Times.Once);
            notificationServiceMock.Verify(x => x.SendNotificationAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }
    }
}
