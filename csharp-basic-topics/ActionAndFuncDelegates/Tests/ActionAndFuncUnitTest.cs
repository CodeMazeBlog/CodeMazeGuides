using App;

namespace Tests;

public class ActionAndFuncUnitTest
{
    [Fact]
    public void Given_When_FuncAndActionHasRequiredParameters_Then_ShouldReturnFullName()
    {
        var funcAndAction = new ActionAndFunc();
        funcAndAction.Run("John", "Doe");
        Assert.NotNull(funcAndAction.FullName);
    }
}