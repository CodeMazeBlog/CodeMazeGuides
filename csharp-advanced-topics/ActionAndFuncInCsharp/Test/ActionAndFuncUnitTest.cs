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
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.display();
                string expected = $"Hello is printed {Environment.NewLine}";
                Assert.That(true,expected, sw.ToString());

                StringWriter newOut = new StringWriter();
                Console.SetOut(newOut);
            }
        }

        [Test]
        public void TestActionWithParameter_WhenCustomInputGiven_ThenPrintSentence()
        {
            Program.printEmployeeNameAndNo("John", 124);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.printEmployeeNameAndNo("John", 124);

                string expected = "Employee Name: John,and No: 124";
                Assert.That(true, expected, sw.ToString());

                StringWriter newOut = new StringWriter();
                Console.SetOut(newOut);
            }
        }

        [Test]
        public void TestFuncWithoutParameter_WhenNoInputGiven_ThenPrintHello()
        {
            var outputString = Program.sayHello();
            string expected = "Hello";
            Assert.That(true, expected, outputString);
        }

        [Test]
        public void TestFuncParameter_WhenInputGiven_ThenPrintSum()
        {
            var v = Program.add(10, 20);
            Assert.AreEqual(30, v);
        }

    }
}