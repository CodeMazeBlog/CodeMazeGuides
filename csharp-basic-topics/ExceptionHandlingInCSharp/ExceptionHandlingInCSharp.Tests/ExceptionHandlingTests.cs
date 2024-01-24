namespace ExceptionHandlingInCSharp.Tests;

public class ExceptionHandlingTests
{

    [Test]
    public void GivenThatIAmGettingAUser_WhenTheUserIdIsEqualTo1_ShouldReturnTheRequestUser()
    {
        var expectedUser = new User
        {
            Id = 1,
            Name = "Code Maze"
        };
        var response = SampleRunner.GetUserById(1);
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
        const string expectedErrorMessage = "User not found.";
        var response = SampleRunner.GetUserById(100);
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
        const string expectedErrorMessage = "User ID should be less than 1000.";
        var response = SampleRunner.GetUserById(1000);
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
        const string expectedErrorMessage = "User Id should be a positive number.";
        var response = SampleRunner.GetUserById(0);
        Assert.That(response, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.IsSuccessful, Is.False);
            Assert.That(response.User, Is.Null);
            Assert.That(response.ErrorMessage, Is.EqualTo(expectedErrorMessage));
        });
    }
}