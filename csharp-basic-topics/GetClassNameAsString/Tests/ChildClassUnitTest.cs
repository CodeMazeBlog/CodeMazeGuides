namespace GetClassNameAsString.Tests;

[Collection("Sequential")]
public class ChildClassUnitTest
{
    [Fact]
    public void WhenGetNameByGetCurrentMethod_ThenCorrectName()
    {
        string expected = "ChildClass";
        var childClass = new ChildClass();
        var name = childClass.GetNameByGetCurrentMethod();
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenGetNameByGetType_ThenCorrectName()
    {
        string expected = "ChildClass";
        var childClass = new ChildClass();
        var name = childClass.GetNameByGetType();
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenStaticGetNameByGetCurrentMethod_ThenCorrectName()
    {
        string expected = "BaseClass";
        var name = ChildClass.StaticGetNameByGetCurrentMethod();
        Assert.Equal(expected, name);
    }

    [Fact]
    public void WhenGetMyPropertyInt_ThenCorrectName()
    {
        string expected = """
                           BaseClass GetCurrentMethod in the property getter result: BaseClass
                           BaseClass GetType in the property getter result: ChildClass

                           """;
        var childClass = new ChildClass();
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        int myPropertyInt = childClass.MyPropertyInt;

        Assert.Equal(expected, stringWriter.ToString());
    }

    [Fact]
    public void WhenSetMyPropertyInt_ThenCorrectName()
    {
        string expected = """
                           BaseClass GetCurrentMethod in the property setter result: BaseClass
                           BaseClass GetType in the property setter result: ChildClass

                           """;
        var childClass = new ChildClass();
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        childClass.MyPropertyInt = 1;

        Assert.Equal(expected, stringWriter.ToString());
    }
}