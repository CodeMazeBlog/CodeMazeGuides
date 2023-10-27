using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MathTests
{
    [DataTestMethod]
    [DataRow(15, 13, 2)]
    public void GivenNumbers_WhenSubtracting_ThenReturnCorrectResult(int a, int b, int expected)
    {
        // Arrange
        Func<int, int, int> Sub = (x, y) => x - y;

        // Act
        int result = Sub(a, b);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
