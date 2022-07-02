namespace Tests;

public class UnitTest1
{
    [Fact]
    public void BasicAction()
    {
        //arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Action greetings = () => Console.WriteLine("Hello, World!");
        //act
        greetings();
        //assert
        Assert.Equal("Hello, World!\r\n", stringWriter.ToString());
    }

    [Fact]
    public void ActionWithSingleParameter()
    {
        //arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Action<int> substructTwo = (num) => Console.WriteLine(num - 2);
        //act
        substructTwo(50);
        //assert
        Assert.Equal("48\r\n", stringWriter.ToString());
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