using FluentAssertions;
using NSubstitute;

namespace MockingWithNSubstitute.Tests
{
    public class NotificationServiceTests
    {
        private readonly IEmailService _emailService;
        private readonly NotificationService _notificationService;

        public NotificationServiceTests()
        {
            _emailService = Substitute.For<IEmailService>();
            _notificationService = new NotificationService(_emailService);
        }

        [Fact]
        public void GivenInputIsCorrect_WhenNotifyUserIsInvoked_ThenTrueIsReturned()
        {
            // Arrange
            var user = new User("Some Name", "email@code-maze.com");
            var message = "Mocking behaviors and expectations with NSubstitute";
            _emailService.IsValidEmail(user.Email).Returns(true);
            _emailService.SendEmail(user.Email, "Notification from CodeMaze", message).Returns(true);

            // Act
            var result = _notificationService.NotifyUser(user, message);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void GivenInputIsNotCorrect_WhenNotifyUserIsInvoked_ThenFalseIsReturned()
        {
            // Arrange
            var user = new User("Some Name", "email@code-maze.com");
            var message = "Ignoring or Conditionally Matching Arguments";
            _emailService.IsValidEmail(default).ReturnsForAnyArgs(false);
            _emailService.SendEmail(Arg.Any<string>(), Arg.Is<string>(x => x.Length > 5), message).Returns(true);

            // Act
            var result = _notificationService.NotifyUser(user, message);

            // Assert
            result.Should().BeFalse();
        }
    }
}
