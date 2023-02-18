using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncAndActionCsharp;

namespace Tests
{
    [TestFixture]
    public class FuncActionExampleTests
    {
        [Test]
        public void TestGreetingAction()
        {
            // Arrange
            FuncActionExample funcActionExample = new FuncActionExample();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Action<string> say = funcActionExample.Greeting;
            say("Hello");

            // Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo("Hello\r\n"));
        }

        [Test]
        public void TestAddFunc()
        {
            // Arrange
            FuncActionExample funcActionExample = new FuncActionExample();

            // Act
            Func<int, int, int> calculate = funcActionExample.Add;
            int result = calculate(2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void TestCheckDelegate()
        {
            // Arrange
            FuncActionExample funcActionExample = new FuncActionExample();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            funcActionExample.CheckDelegate();

            // Assert
            Assert.That(stringWriter.ToString(), Is.EqualTo("Results using Func and Action\r\nHello\r\n5\r\n"));
        }
    }

}
