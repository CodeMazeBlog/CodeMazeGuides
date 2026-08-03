using RefactoringChangePreventers.ShotgunSurgery.Correct;
using Action = RefactoringChangePreventers.ShotgunSurgery.Correct.Action;

namespace RefactoringChangePreventersTests;

[TestClass]
public class UserUnitTests
{
    [TestMethod]
    public void WhenModifyingFirstName_ThenFirstNameShouldBeModifiedAndActionsShouldBeUpdated()
    {
        // Arrange
        var user = new User { Id = 1, FirstName = "John", LastName = "Doe", Actions = new List<Action>() };
        var expectedFirstName = "Jane";

        // Act
        user.ModifyFirstName(expectedFirstName);

        // Assert
        Assert.AreEqual(expectedFirstName, user.FirstName);
        Assert.AreEqual(1, user.Actions.Count);
        Assert.AreEqual(nameof(User.ModifyFirstName), user.Actions.First().ActionName);
        Assert.AreEqual(user.Id, user.Actions.First().UserId);
    }

    [TestMethod]
    public void WhenModifyingLastName_ThenLastNameShouldBeModifiedAndActionsShouldBeUpdated()
    {
        // Arrange
        var user = new User { Id = 1, FirstName = "John", LastName = "Doe", Actions = new List<Action>() };
        var expectedLastName = "Smith";

        // Act
        user.ModifyLastName(expectedLastName);

        // Assert
        Assert.AreEqual(expectedLastName, user.LastName);
        Assert.AreEqual(1, user.Actions.Count);
        Assert.AreEqual(nameof(User.ModifyLastName), user.Actions.First().ActionName);
        Assert.AreEqual(user.Id, user.Actions.First().UserId);
    }
}