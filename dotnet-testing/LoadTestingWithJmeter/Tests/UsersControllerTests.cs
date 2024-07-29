namespace Tests;

public class UsersControllerTests
{
    [Fact]
    public void GivenUserController_WhenGetInvoked_ThenReturnOk()
    {
        // Arrange
        var userService = new Mock<IUserService>();
        userService.Setup(x => x.GetUsers()).Returns([]);
        var controller = new UsersController(userService.Object);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GivenUserController_WhenPostInvoked_ThenReturnCreatedAtAction()
    {
        // Arrange
        var userService = new Mock<IUserService>();
        var user = new User(1, "Sam K", "sam.k@gmail.com");
        var controller = new UsersController(userService.Object);

        // Act
        var result = controller.Post(user);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}