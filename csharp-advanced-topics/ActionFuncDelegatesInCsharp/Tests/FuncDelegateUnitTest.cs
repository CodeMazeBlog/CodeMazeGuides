namespace Tests
{
    public class FuncDelegateUnitTest
    {

        [Fact]
        public void AddIntegers_NoSubscribers_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.AddIntegers(10, 20);

            // Assert
            Assert.Equal(30, result);
        }


        [Fact]
        public void AddIntegers_WithSubscriber_CallsSubscriberAndReturnsSubscriberResult()
        {
            // Arrange
            var calculator = new Calculator();
            string consoleOutput;

            // Redirect console output to a StringWriter
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Subscribe to the OnAddIntegers event.
                calculator.OnAddIntegers += (a, b) =>
                {
                    Console.WriteLine($"The sum of {a} and {b} is {a + b}.");
                    return 0; // Return a dummy value.
                };

                // Act
                int result = calculator.AddIntegers(10, 20);

                // Get the console output before disposing of the StringWriter
                consoleOutput = sw.ToString();

                // Assert
                Assert.Equal(0, result); // Assuming you want to check the subscriber's return value
            }

            // Additional assertions on the console output
            Assert.Contains("The sum of 10 and 20 is 30.", consoleOutput);
        }

    }
}