using Firebase.Dtos;
using Firebase.Interfaces;
using Firebase.Pages.Auth;
using Moq;

namespace Tests;
public class FirestoreAuthSignUpTests
{
	private readonly Mock<IFirebaseAuthService> _authService;

	public FirestoreAuthSignUpTests()
	{
		_authService = new Mock<IFirebaseAuthService>();
	}

	[Fact]
	public async Task GivenAValidSignUpForm_WhenSubmittingForm_ThenSignsUserUp()
	{
		// Arrange
		var userDto = new UserDto
		{
			Email = "test@test.com",
			Password = "password"
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
