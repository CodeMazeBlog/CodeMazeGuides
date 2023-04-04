namespace GetClassNameAsString.Tests;

[Collection("Sequential")]
public class ProgramUnitTest
{
    [Theory]
    [InlineData(nameof(Program))]
    public void WhenUseNameOf_ThenCorrectName(string expected)
    {
        var name = nameof(Program);
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenUseTypeOf_ThenCorrectName()
    {
        string expected = "Program";
        var name = typeof(Program).Name;
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenUseGetTypeOfInstance_ThenCorrectName()
    {
        string expected = "Program";
        Program p = new();
        var name = p.GetType().Name;
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenUseGetCurrentMethodDeclaringType_ThenCorrectName()
    {
        var expected = "ProgramUnitTest";
        var name = MethodBase.GetCurrentMethod()!.DeclaringType!.Name;
        Assert.Equal(expected, name);
    }
}