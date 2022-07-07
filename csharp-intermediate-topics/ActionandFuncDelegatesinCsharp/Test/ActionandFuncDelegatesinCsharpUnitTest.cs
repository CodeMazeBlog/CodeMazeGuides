using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class ActionandFuncDelegatesinCsharpUnitTest
    {
        [TestMethod]
        public void GivenFuncDelegate_WhenCalculatingAge_ThenReturnCorrectValue()
        {
            Func<DateTime, int> CalculateAge = (dateOfBirth) =>
            {
                int age = 0;
                age = DateTime.Now.Subtract(dateOfBirth).Days;
                age = age / 365;
                return age;
            };

            Assert.AreEqual(30, CalculateAge(Convert.ToDateTime("5/14/1992")));
        }

        [TestMethod]
        public void GivenFuncDelegate_WhenCalculatingSqaureRoot_ThenReturnCorrectValue()
        {
            double GetSquareRoot(int number)
            {
                return Math.Sqrt(number);
            }

            Func<int, double> GetSquareRootFunc = GetSquareRoot;

            Assert.AreEqual(6, GetSquareRootFunc(36));
        }

        [TestMethod]
        public void GivenActionDelegate_WhenGivenFirstNameAndLastName_ThenGreetsWithFullName()
        {
            var currentConsoleOut = Console.Out;

            string text = "Good day, John Doe.\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                Action<string> Greetings = (name) => Console.WriteLine($"Good day, {name}.");

                Greetings("John Doe");

                Assert.AreEqual(text, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}