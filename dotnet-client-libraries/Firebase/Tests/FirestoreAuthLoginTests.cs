using Firebase.Dtos;
using Firebase.Interfaces;
using Firebase.Pages.Auth;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;
public class FirestoreAuthLoginTests
{
	private readonly Mock<IFirebaseAuthService> _authService;

	public FirestoreAuthLoginTests()
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
