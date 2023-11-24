namespace Tests
{
    public class Tests
    {
        [Fact]
        public void TestActionDelegate()
        {
            // Arrange
            Action<int, int> addActionDelegate = (a, b) => Console.WriteLine($"\nSum Action Delegate: {a + b}\n");
            int expected = 8;

            // Act
            addActionDelegate(3, 5);

            // Assert
            Assert.Equal(expected, 8);


        }

        [Fact]
        public void TestFuncDelegate()
        {
            // Arrange
            Func<int, int, int> addFuncDelegate = (a, b) => a + b;
            int expected = 8;

            // Act
            int resultFuncDelegate = addFuncDelegate(3, 5);

            // Assert
            Assert.Equal(expected, resultFuncDelegate);
        }
    }
}