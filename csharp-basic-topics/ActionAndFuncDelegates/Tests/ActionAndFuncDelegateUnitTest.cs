namespace Tests
{
    public class DelegateExample
    {
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public void GreetPerson(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

    [TestClass]
    public class DelegateExampleTests
    {
        [TestMethod]
        public void FuncDelegate_AddNumbers_ReturnsSum()
        {
            // Arrange
            var example = new DelegateExample();
            Func<int, int, int> addMethod = example.AddNumbers;

            // Act
            int result = addMethod(3, 5);

            // Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void ActionDelegate_GreetPerson_ConsoleOutputContainsGreeting()
        {
            // Arrange
            var example = new DelegateExample();
            Action<string> greetMethod = example.GreetPerson;

            // Redirect console output for testing
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                greetMethod("John");

                // Assert
                string expectedOutput = "Hello, John!\r\n";
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}