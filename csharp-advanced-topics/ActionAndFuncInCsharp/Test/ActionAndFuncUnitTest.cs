using ActionAndFuncInCsharp;
using System.Xml.Linq;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestParameterlessAction_WhenNoInput_ThenPrintHello()
        {
            string expected = $"Enjoy your day!{Environment.NewLine}";
            using StringWriter sw = new();
            Console.SetOut(sw);

            Program.display();

            Assert.AreEqual(expected, sw.ToString());
        }

        [Test]
        public void TestActionWithParameter_WhenCustomInputGiven_ThenPrintSentence()
        {
            string expected = $"Employee Name: John,and No: 124{Environment.NewLine}";
            using StringWriter sw = new();
            Console.SetOut(sw);

            Program.printEmployeeNameAndNo("John", 124);

            Assert.AreEqual(expected, sw.ToString());
        }

        [Test]
        public void TestFuncWithoutParameter_WhenNoInputGiven_ThenPrintHello()
        {
            string expected = "Hello";

            var outputString = Program.sayHello();
            
            Assert.AreEqual(expected, outputString);
        }

        [Test]
        public void TestFuncParameter_WhenInputGiven_ThenPrintSum()
        {
            var v = Program.add(10, 20);
            Assert.AreEqual(30, v);
        }
    }
}