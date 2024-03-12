namespace Tests
{
    [TestClass]
    public class Tests
    {
        delegate int DelegateOfMethod(int x);
        private static int Product(int x) => x * x;
        private static int MethodUsesDelegate(DelegateOfMethod del, int x) => del(x);

        private static int Sum(int x) => x + x;

        [TestMethod]
        public void GivenADelegateForProductMethod_WhenInvokedWithANumber_ReturnsSameOutputAsMethod()
        {
            int methodOp = Product(5);
            int delegateOp = new DelegateOfMethod(Product)(5);
            Assert.AreEqual(methodOp, delegateOp);
        }
        [TestMethod]
        public void GivenADelegateForSumMethod_WhenInvokedWithANumber_ReturnsSameOutputAsMethod()
        {
            int methodOp = Sum(5);
            int delegateOp = new DelegateOfMethod(Sum)(5);
            Assert.AreEqual(methodOp, delegateOp);
        }
        [TestMethod]
        public void GivenDelegateAsParameter_WhenInvokedWithAnyNumber_ReturnsSameOutputAsOriginalMethod()
        {
            int methodOp = Sum(5);
            int delegateOp = MethodUsesDelegate(new DelegateOfMethod(Sum), 5);
            Assert.AreEqual(methodOp, delegateOp);
        }
        [TestMethod]
        public void GivenDelegateAsParameter_WhenInvokedWithAnyNumber_ReturnsSameOutputAsOriginalMethod_ForSum()
        {
            int methodOp = Product(5);
            int delegateOp = MethodUsesDelegate(new DelegateOfMethod(Product), 5);
            Assert.AreEqual(methodOp, delegateOp);
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