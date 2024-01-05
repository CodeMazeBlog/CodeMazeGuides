namespace FuncAndActionDelegate.Test;

[TestClass]
public class ActionExTest
{
    [TestMethod]
    public void ActionRealExample_ShouldWriteDataToConsole()
    {
        // Arrange
        List<string> expectedResult = new List<string> { "Test1", "Test2", "Test3" };
        ActionEx actionEx = new ActionEx();

        // Act
        var actualResult =actionEx.ActionRealExample(expectedResult);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);

    }

   
}
