using ActionAndFunc;

namespace TestProject1;

public class ActionDelegateUnitTest
{
    [Fact]
    public void ExecuteActionDelegate_ShouldReturnCorrectName()
    {
        // Arrange
        var actionDelegate = new ActionDelegate();
        var name = "Yohan";

        // Act
        var result = actionDelegate.ExecuteActionDelegate(name);

        // Assert
        Assert.Equal(name, result);
    }
}