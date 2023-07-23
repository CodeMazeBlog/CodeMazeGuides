using FirebaseAuthentication.Dtos;
using FirebaseAuthentication.Interfaces;
using FirebaseAuthentication.Pages.Auth;
using Moq;

namespace Tests;
public class FirebaseAuthLoginTests
{
    private readonly Mock<IFirebaseAuthService> _authService;

    public FirebaseAuthLoginTests()
    {
        _authService = new Mock<IFirebaseAuthService>();
    }

    [Fact]
    public async Task GivenAValidUser_WhenSubmittingForm_ThenLogsUserIn()
    {
        // Arrange
        var userDto = new UserDto
        {
            Email = "test@test.com",
            Password = "password"
        };

        var page = new LoginModel(_authService.Object)
        {
            UserDto = userDto
        };

        // Act
        await page.OnPostAsync();

        // Assert
        _authService.Verify(a => a.Login(userDto.Email, userDto.Password), Times.Once);
    }
}
