namespace FuncAndActionDelegate.Test;

[TestClass]
public class FuncExampleTests
{
    [TestMethod]
    public void Calculate_AddNumbers_ReturnsCorrectResult()
    {
        // Arrange
        FuncEx funcExample = new FuncEx();

        // Act
        int result = funcExample.Calculate(5, 3, (x, y) => x + y);

        // Assert
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Calculate_SubtractNumbers_ReturnsCorrectResult()
    {
        // Arrange
        FuncEx funcExample = new FuncEx();

        // Act
        int result = funcExample.Calculate(5, 3, (x, y) => x - y);

        // Assert
        Assert.AreEqual(2, result);
    }
   
    [TestMethod]
    public void FuncRealExample_ShouldHandleEmptyData()
    {
        // Arrange
        FuncEx funcExample = new FuncEx();
        List<string> data = new List<string>() { "Test1","Test3"};

        // Act
        IEnumerable<string> filteredData = funcExample.FuncRealExample(data);

        // Assert
        Assert.IsNotNull(filteredData);
    }

    [TestMethod]
    public void FuncRealExample_ShouldHandleNullData()
    {
        // Arrange
        FuncEx funcExample = new FuncEx();
        List<string> data = null;

        // Act
        IEnumerable<string> filteredData = funcExample.FuncRealExample(data!);

        // Assert
        Assert.IsNull(filteredData);
    }
}
