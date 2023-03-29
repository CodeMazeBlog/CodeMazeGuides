namespace Tests
{
    public class Tests
    {

        static int DifferenceBetweenTwoNumbers(int a, int b)
        {
            return a - b;
        }

        static void MyVoidMethodWithArgument(string str)
        {
            Console.WriteLine($"This is an Action with {str} as string parameter");
        }

        static void MyVoidMethod()
        {
            Console.WriteLine("This is my first Action");
        }

        [Test]
        public void TestDifferenceBetweenTwoNumbers()
        {
            Func<int, int, int> SunstractionOfNumbers = DifferenceBetweenTwoNumbers;

            int rest = SunstractionOfNumbers(9, 4);

            Assert.That(rest, Is.EqualTo(5));
        }

        [Test]
        public void TestSubstractionResult()
        {
            Func<int, int, int> SubstractionResult = (a, b) => a - b;

            int rest = SubstractionResult(8, 6);

            Assert.That(rest, Is.EqualTo(2));
        }

        [Test]
        public void TestIsDecimalNumber()
        {
            Func<int, bool> IsDecimalNumber = num => num > 10;

            int[] numbers = { 1, 4, 11, 2, 15, 7 };

            IEnumerable<int> decimalNumber = numbers.Where(IsDecimalNumber);

            Assert.IsTrue(decimalNumber.SequenceEqual(new[] { 11, 15 }));
        }

        [Test]
        public void TestMyVoidMethodWithArgument()
        {
            string str = "Code-Maze";

            MyVoidMethodWithArgument(str);

            Assert.Pass();
        }

        [Test]
        public void TestMyVoidMethod()
        {
            MyVoidMethod();

            Assert.Pass();
        }
    }
}