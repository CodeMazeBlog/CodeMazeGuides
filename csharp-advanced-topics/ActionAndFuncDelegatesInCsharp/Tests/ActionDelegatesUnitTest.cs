using Xunit;
using System;
using System.IO;

namespace Tests
{
    public class ActionDelegatesUnitTest
    {
        static void PrintName() => Console.WriteLine($"My name is Tobby");
        static void FullNameAndAge(string fullName, int age) => Console.WriteLine($"My full name is {fullName}, and i am {age} years old");
        static void UsingActionDelegates()
        {
            Action printName = PrintName;
            printName();
        }

        [Fact]
        public void whenDelegateIsChecked_thenConfirmType()
        {
            var Actiondelegate = UsingActionDelegates;

            Assert.IsType<Action>(Actiondelegate);
        }

        [Theory]
        [InlineData("Umoh Tobby", 23, "My full name is Umoh Tobby, and i am 23 years old")]
        public void whenNameAndAgeIsEntered_thenConfirmFullNameAndAge(string fullName, int age, string expected)
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                var action2 = FullNameAndAge;

                action2(fullName, age);

                var actual = consoleOutput.GetOuput();

                Assert.Equal(expected, actual);
            }
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter output;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            output = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            var getStringWriter = Convert.ToString(stringWriter);
            var getString = getStringWriter.Replace("\r\n", "");

            return getString;
        }

        public void Dispose()
        {
            Console.SetOut(output);
            stringWriter.Dispose();
        }
    }
}
