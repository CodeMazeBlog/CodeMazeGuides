using static Program;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GivenAnInteger_ProductReturnsSquare()
        {
            int input = 5, expected = 25;
            int methodOp = Program.Product(input);

            Assert.AreEqual(expected, methodOp);
        }
        [TestMethod]
        public void GivenAnInteger_SumReturnsTWiceItsValue()
        {
            int input = 5, expected = 10;
            int methodOp = Program.Sum(input);

            Assert.AreEqual(expected, methodOp);
        }
        [TestMethod]
        public void GivenAnyInteger_ProductAndDelegateReturnSame()
        {
            int input = 5, expected = 25;
            var delProduct = new DelegateOfMethod(Program.Product);
            int result = Program.MethodUsesDelegate(delProduct, input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GivenAnyInteger_SumAndDelegateReturnSame()
        {
            int input = 5, expected = 10;
            var delProduct = new DelegateOfMethod(Program.Sum);
            int result = Program.MethodUsesDelegate(delProduct, input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Given_AdditionDelegate_When_InvokeWithAnyPositiveIntegers_Then_ReturnsTheirSum()
        {
            Func<int, int, int> del = (x, y) => { return (x + y); };
            int result = del(1, 2);

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Given_MultiplicationDelegate_When_InvokeWithAnyPositiveIntegers_Then_ReturnsTheirProduct()
        {
            Func<int, int, int> del = (x, y) => { return (x * y); };
            int result = del(1, 2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Given_AdditionDelegate_When_InvokeWithNegativeIntegers_Then_ReturnsNegativeInteger()
        {
            Func<int, int, int> del = (x, y) => { return (x + y); };
            int result = del(-5, -3);

            Assert.AreEqual(-8, result);
        }

        [TestMethod]
        public void Given_MultiplicationDelegate_When_InvokeWithZeroAndZero_Then_ReturnsZero()
        {
            Func<int, int, int> del = (x, y) => { return (x * y); };
            int result = del(0, 0);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Given_AdditionThenMultiplicationDelegate_When_InvokeWithAnyPositiveIntegers_Then_ReturnsProperValue()
        {
            Func<int, int, int> del = (x, y) => { return (x + y); };
            del = (x, y) => { return (x * y); };
            int result = del(1, 2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Given_ListOfNumbers_When_ForEachPrinted_Then_PrintsEachNumber()
        {
            List<int> numbers = [1, 2, 3, 4, 5];
            List<int> printedNumbers = [];
            numbers.ForEach(x => printedNumbers.Add(x));

            CollectionAssert.AreEqual(numbers, printedNumbers);
        }

        [TestMethod]
        public void Given_ListOfNumbers_When_ForEachSquaredPrinted_Then_PrintsSquareOfEachNumber()
        {
            List<int> numbers = [1, 2, 3, 4, 5];
            List<int> squaredNumbers = [];
            numbers.ForEach(x => squaredNumbers.Add(x * x));

            CollectionAssert.AreEqual(new List<int> { 1, 4, 9, 16, 25 }, squaredNumbers);
        }
    }
}