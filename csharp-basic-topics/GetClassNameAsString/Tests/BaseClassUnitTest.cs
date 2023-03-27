namespace GetClassNameAsString.Tests;

public class BaseClassUnitTest
{
    [Fact]
    public void WhenGetNameByGetCurrentMethod_ThenCorrectName()
    {
        string expected = "BaseClass";
        var baseClass = new BaseClass();
        var name = baseClass.GetNameByGetCurrentMethod();
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenGetNameByGetType_ThenCorrectName()
    {
        string expected = "BaseClass";
        var baseClass = new BaseClass();
        var name = baseClass.GetNameByGetType();
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenStaticGetNameByGetCurrentMethod_ThenCorrectName()
    {
        string expected = "BaseClass";
        var name = BaseClass.StaticGetNameByGetCurrentMethod();
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenGetMyPropertyInt_ThenCorrectName()
    {
        string expected = """
                           BaseClass GetCurrentMethod in the property getter result: BaseClass
                           BaseClass GetType in the property getter result: BaseClass

                           """;
        var baseClass = new BaseClass();
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        int myPropertyInt = baseClass.MyPropertyInt;

        Assert.Equal(expected, stringWriter.ToString());
    }

    [Fact]
    public void WhenSetMyPropertyInt_ThenCorrectName()
    {
        string expected = """
                           BaseClass GetCurrentMethod in the property setter result: BaseClass
                           BaseClass GetType in the property setter result: BaseClass

                           """;
        var baseClass = new BaseClass();
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        baseClass.MyPropertyInt = 1;

        Assert.Equal(expected, stringWriter.ToString());
    }
}