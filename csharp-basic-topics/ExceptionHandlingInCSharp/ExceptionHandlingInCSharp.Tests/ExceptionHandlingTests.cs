namespace ExceptionHandlingInCSharp.Tests;

public class ExceptionHandlingTests
{
    [Test]
    public void GivenThatIAmGettingAUser_WhenTheUserIdIsEqualTo1_ShouldReturnTheRequestUser()
    {
        // Arrange
        var expectedUser = new User
        {
            Id = 1,
            Name = "Code Maze"
        };

        // Act
        var response = SampleRunner.GetUserById(1);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.True);
            Assert.That(response.User, Is.Not.Null);
            Assert.That(response.User!.Id, Is.EqualTo(expectedUser.Id));
            Assert.That(response.User!.Name, Is.EqualTo(expectedUser.Name));
        });
    }
    [Test]
    public void GivenThatIAmGettingAUser_WhenTheUserDoesNotExist_ShouldReturnErrorResponse()
    {
        // Arrange
        const string expectedErrorMessage = "User not found.";

        // Act
        var response = SampleRunner.GetUserById(100);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(response.User, Is.Null);
            Assert.That(response.ErrorMessage, Is.EqualTo(expectedErrorMessage));
        });
    }

    [Test]
    public void GivenThatIAmGettingAUser_WhenTheUserIdIsEqualTo1000_ShouldReturnErrorResponse()
    {
        // Arrange
        const string expectedErrorMessage = "User ID should be less than 1000.";

        // Act
        var response = SampleRunner.GetUserById(1000);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(response.User, Is.Null);
            Assert.That(response.ErrorMessage, Is.EqualTo(expectedErrorMessage));
        });
    }

    [Test]
    public void GivenThatIAmGettingAUser_WhenTheUserIdIsEqualToZero_ShouldReturnErrorResponse()
    {
        // Arrange
        const string expectedErrorMessage = "User Id should be a positive number.";

        // Act
        var response = SampleRunner.GetUserById(0);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(response.User, Is.Null);
            Assert.That(response.ErrorMessage, Is.EqualTo(expectedErrorMessage));
        });
    }
}
