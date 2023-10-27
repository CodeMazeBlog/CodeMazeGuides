using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MathTests
{
    [TestCase(2)]
    public void GivenStringInput_WhenActionIsCalled_ThenPrintsTheInput()
    {
        // Arrange
        Func<int, int, int> Sub = (a, b) => a - b;

        // Act
        var result = Sub(15, 13);

        // Assert
        Assert.AreEqual(2, result);
    }
}
