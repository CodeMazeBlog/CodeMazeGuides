using ActionAndFuncDelegates;

namespace Tests
{

    [TestClass]
    public class DelegateExampleTests
    {
        [TestMethod]
        public void GivenAddNumbersMethod_WhenInvokeFuncDelegate_ThenReturnsSum()
        {
            // Arrange
            var example = new DelegateExample();
            Func<int, int, int> addMethod = example.AddNumbers;

            // Act
            var result = addMethod(3, 5);

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void GivenGreetPersonMethod_WhenInvokeActionDelegate_ThenConsoleOutputContainsGreeting()
        {
            // Arrange
            var example = new DelegateExample();
            Action<string> greetMethod = example.GreetPerson;

            // Redirect console output for testing
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                greetMethod("John");

                // Assert
                var expectedOutput = "Hello, John!" + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}