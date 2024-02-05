namespace ActionDemoTest;

public class ActionDelegatTest
{
    [Fact]
    public void ActionTest()
    {
        var names = new List<string> { "Alice", "Bob", "Charlie" };
        Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        names.ForEach(greet);

        // Assert
        var outputString = output.ToString();
        Assert.Contains("Hello, Alice!", outputString);
        Assert.Contains("Hello, Bob!", outputString);
        Assert.Contains("Hello, Charlie!", outputString);

        // Cleanup
        Console.SetOut(Console.Out);
    }
}