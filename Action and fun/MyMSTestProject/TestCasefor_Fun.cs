using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MathTests
{
    [TestMethod]
    public void TestSubtraction()
    {
        // Arrange
        Func<int, int, int> Sub = (a, b) => a - b;

        // Act
        int result = Sub(15, 13);

        // Assert
        Assert.AreEqual(2, result);
    }
}
