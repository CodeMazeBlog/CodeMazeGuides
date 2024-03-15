namespace MockingWithNSubstitute.Tests;

public class NotificationServiceTests
{
    private readonly User _user;
    private readonly IEmailService _emailService;
    private readonly NotificationService _notificationService;

    public NotificationServiceTests()
    {
        _user = new User("Code-Maze", "email@code-maze.com");
        _emailService = Substitute.For<IEmailService>();
        _notificationService = new NotificationService(_emailService);
    }

    [Fact]
    public void GivenInputIsCorrect_WhenNotifyUserIsInvoked_ThenTrueIsReturned()
    {
        // Arrange            
        const string message = "Mocking behaviors and expectations with NSubstitute";
        _emailService.IsValidEmail(_user.Email)
            .Returns(true);
        _emailService.SendEmail(_user.Email, "Notification from CodeMaze", message)
            .Returns(true);

        // Act
        var result = _notificationService.NotifyUser(_user, message);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenInputIsNotCorrect_WhenNotifyUserIsInvoked_ThenFalseIsReturned()
    {
        // Arrange
        const string message = "Ignoring or Conditionally Matching Arguments";
        _emailService.IsValidEmail(default)
            .ReturnsForAnyArgs(false);
        _emailService.SendEmail(Arg.Any<string>(), Arg.Is<string>(x => x.Length > 5), message)
            .Returns(true);

        // Act
        var result = _notificationService.NotifyUser(_user, message);

        // Assert
        result.Should().BeFalse();
        _emailService.Received().IsValidEmail(Arg.Any<string>());
        _emailService.DidNotReceive().SendEmail(Arg.Any<string>(), Arg.Is<string>(x => x.Length > 5), message);
    }

    [Fact]
    public void GivenExceptionIsThrown_WhenNotifyUserIsInvoked_ThenFalseIsReturned()
    {
        // Arrange
        const string message = "Throwing Exceptions When Mocking With NSubstitute";
        _emailService.IsValidEmail(_user.Email)
            .Returns(true);
        _emailService.When(x => x.SendEmail(_user.Email, "Notification from CodeMaze", message))
            .Do(x => { throw new InvalidEmailException(); });

        // Act
        var act = () => _notificationService.NotifyUser(_user, message);

        // Assert
        act.Should().ThrowExactly<InvalidEmailException>();
    }
}
