using Xunit;
using System;
using System.IO;
using System.Text.RegularExpressions;

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
            Action Actiondelegate = UsingActionDelegates;

            Assert.IsType<Action>(Actiondelegate);
        }

        [Theory]
        [InlineData("Umoh Tobby", 23, "My full name is Umoh Tobby, and i am 23 years old")]
        public void whenNameAndAgeIsEntered_thenConfirmFullNameAndAge(string fullName, int age, string? expected)
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                Action<string,int> action2 = FullNameAndAge;

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

        public string? GetOuput()
        {
            var getStringWriter = Convert.ToString(stringWriter);
            var getString = getStringWriter != null ? Regex.Replace(getStringWriter, @"\t|\n|\r", String.Empty) : getStringWriter;

            return getString;
        }

        public void Dispose()
        {
            Console.SetOut(output);
            stringWriter.Dispose();
        }
    }
}
