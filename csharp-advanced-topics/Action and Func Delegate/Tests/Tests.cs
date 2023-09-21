namespace Tests
{
    public delegate int CalculateDelegate(int a, int b);

    [TestClass]
    public class Tests
    {
        private static int Add(int a, int b)
        {
            return a + b;
        }

        [TestMethod]
        public void When3and5isPassed_ThenCalculateDelegateReturns8()
        {
            var delegate1 = new CalculateDelegate(Add);
            var result = delegate1.Invoke(3, 5);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void When3and5isPassed_ThenFuncDelegateReturns8()
        {
            var funcDelegate = new Func<int, int, int>(Add);
            var result = funcDelegate(3, 5);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void When3and5isPassed_ThenFuncDelegateAndCalculateDelegateBothReturns8()
        {
            var delegate1 = new CalculateDelegate(Add);
            var delegate1Result = delegate1.Invoke(3, 5);

            var funcDelegate = new Func<int, int, int>(Add);
            var funcDelegateResult = funcDelegate(3, 5);

            Assert.AreEqual(funcDelegateResult, delegate1Result);
        }

    }


}