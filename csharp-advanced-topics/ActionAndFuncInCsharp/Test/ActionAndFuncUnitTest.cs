using ActionAndFuncInCsharp;
using System.Xml.Linq;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestParameterlessAction_WhenNoInput_PrintHelloOutput()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.display(); // Call the static method

                string expected = "Hello is printed" + Environment.NewLine;
                Assert.That(true,expected, sw.ToString());

                StringWriter newOut = new StringWriter();
                Console.SetOut(newOut);
            }
        }
        [Test]
        public void TestActionWithParameter_WhenCustomInputGiven()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.printEmployeeNameAndNo("John", 124); // Call the static method

                string expected = "Employee Name: John,and No: 124";
                Assert.That(true, expected, sw.ToString());

                StringWriter newOut = new StringWriter();
                Console.SetOut(newOut);
            }
        }
        [Test]
        public void TestFuncWithoutParameter()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.sayHello();
                
                string expected = "Hello";
                Assert.That(true, expected, sw.ToString());

                StringWriter newOut = new StringWriter();
                Console.SetOut(newOut);
            }
        }
        [Test]
        public void TestFuncParameter_WhenInputGiven_PrintSum()
        {
            var v = Program.add(10, 20);
            Assert.AreEqual(30, v);
        }

    }
}