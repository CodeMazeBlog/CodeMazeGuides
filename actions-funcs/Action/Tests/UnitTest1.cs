namespace Tests;

public class UnitTest1
{
    [Fact]
    public void BasicAction()
    {
        //arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Action greetings = () => Console.Write("Hello, World!");
        //act
        greetings();
        //assert
        Assert.Equal("Hello, World!", stringWriter.ToString());
    }

    [Fact]
    public void ActionWithSingleParameter()
    {
        //arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Action<int> substructTwo = (num) => Console.Write(num - 2);
        //act
        substructTwo(50);
        //assert
        Assert.Equal("48", stringWriter.ToString());
    }

    [Fact]
    public void ActionWithMultipleParameter()
    {
        //arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Action<string, string> caps = (wOne, wTwo) => Console.WriteLine(string.Concat(wOne, wTwo).ToUpper());
        //act
        caps("This", "Rocks");
        //assert
        Assert.Equal("THISROCKS\r\n", stringWriter.ToString());
    }
}