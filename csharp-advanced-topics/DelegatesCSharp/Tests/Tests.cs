namespace Tests
{
    [TestClass]
    public class Tests
    {
        //Example of Action delegate
        public static void PrintMessage()
        {
            Console.WriteLine("Hello, world!");
        }
        static void ExecuteAction(Action action)
        {
            action();
        }

        //Example of Func delegates
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }
        static void ExecuteFunc(Func<int, int, int> func)
        {
            int result = func(10, 20);
            Console.WriteLine("Result = " + result);
        }

        [TestMethod]
        public void TestPrintMessage()
        {
            // Arrange
            string expectedOutput = "Hello, world!\r\n";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                PrintMessage();
                string actualOutput = sw.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [TestMethod]
        public void TestAddNumbers()
        {
            // Arrange
            int a = 10;
            int b = 20;
            int expectedSum = 30;

            // Act
            int actualSum = AddNumbers(a, b);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}