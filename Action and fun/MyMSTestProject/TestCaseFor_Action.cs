using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class MessagePrintTests
{
    [TestMethod]
    public void TestMessagePrint()
    {
        // Arrange
        string content = "Hello, Action!";
        int count = 3;
        string expectedOutput = "Hello, Action!" + Environment.NewLine + "Hello, Action!" + Environment.NewLine + "Hello, Action!" + Environment.NewLine;
        var output = new StringWriter();
        Console.SetOut(output);

        Action<string, int> Message_print = (c, cnt) =>
        {
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine(c);
            }
        };

        // Act
        Message_print(content, count);

        // Assert
        Assert.AreEqual(expectedOutput, output.ToString());
    }
}
