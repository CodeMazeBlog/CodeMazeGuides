using NUnit.Framework;
using System;

[TestFixture]
public class ActionDemoTests
{
    [Test]
    public void TestShowMessageWithBeep()
    {
        // Arrange
        var originalOut = Console.Out;
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        ActionDemo.ShowMessageWithBeep("Test Message");

        // Assert
        Assert.AreEqual("Test Message" + Environment.NewLine, output.ToString());

        // Cleanup
        Console.SetOut(originalOut);
    }

    [Test]
    public void TestActionAsParameter()
    {
        // Arrange
        var originalOut = Console.Out;
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        ActionDemo.ActionAsParameter(Console.WriteLine);

        // Assert
        Assert.AreEqual("I'm an parameter" + Environment.NewLine, output.ToString());

        // Cleanup
        Console.SetOut(originalOut);
    }
}