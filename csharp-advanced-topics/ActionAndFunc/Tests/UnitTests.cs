using ActionAndFunc;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void whenActionDelegate_DelegateInvocationPrintsExpectedResult()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                Action<string> action = Program.PrintToping;

                action("Pepperoni");

                string consoleOutput = stringWriter.ToString().Trim();

                Assert.Equal("Pepperoni was added to your pizza.", consoleOutput);
            }
        }

        [Fact]
        public void whenFuncDelegate_DelegateInvocationReturnsExpectedResult()
        {
            Func<string, string> func = Program.AddToping;

            var result = func("Pepperoni");

            Assert.Equal("Pepperoni was added to your pizza.", result);
        }
    }
}