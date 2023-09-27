using FirebaseAuthentication.Dtos;
using FirebaseAuthentication.Interfaces;
using FirebaseAuthentication.Pages.Auth;
using Moq;

namespace Tests;

public class FirebaseAuthSignUpTests
{
    private readonly Mock<IFirebaseAuthService> _authService;

    public FirebaseAuthSignUpTests()
    {
        _authService = new Mock<IFirebaseAuthService>();
    }

    [Fact]
    public async Task GivenAValidSignUpForm_WhenSubmittingForm_ThenSignsUserUp()
    {
        // Arrange
        var userDto = new SignUpUserDto
        {
            Email = "test@test.com",
            Password = "password",
            ConfirmPassword = "password"
        };

        var page = new SignUpModel(_authService.Object)
        {
            UserDto = userDto
        };

        // Act
        await page.OnPostAsync();

        // Assert
        _authService.Verify(a => a.SignUp(userDto.Email, userDto.Password), Times.Once);
    }
}