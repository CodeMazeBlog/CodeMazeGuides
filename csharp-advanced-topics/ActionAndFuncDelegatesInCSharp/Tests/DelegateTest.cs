using ActionAndFuncDelegatesInCSharp.DelegatesExamples;

namespace Tests
{
    [TestClass]
    public class DelegatesTest
    {
        protected ActionDelegate AD = new ActionDelegate();
        protected FuncDelegate FD = new FuncDelegate();
        protected PredicateDelegate PD = new PredicateDelegate();

        [TestMethod]
        public void GivenMultiplyMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsAMultipliedResult()
        {
            Func<int, int, string> delegateResult = FD.Multiply;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Multiplication Result : 25", result);
        }

        [TestMethod]
        public void GivenAdditionMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsAMultipledResult()
        {
            Func<int, int, string> delegateResult = FD.Add;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Addition Result : 10", result);
        }

        [TestMethod]
        public void GivenDivisionMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsADividedResult()
        {
            Func<int, int, string> delegateResult = FD.Divide;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Division Result : 1", result);
        }

        [TestMethod]
        public void GivenSubtractionMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsASubtractedResult()
        {
            Func<int, int, string> delegateResult = FD.Subtract;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Subtraction Result : 0", result);
        }

        [TestMethod]
        public void GivenTwoIntegers_WhenActionDelegateIsCalledToMultipy_ThenDelegateHasInvocationExecuted()
        {
            Action<int, int> delegateResult = AD.PrintMultiplyResult;
            delegateResult(5, 5);

            Assert.AreEqual(delegateResult.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void GivenAnAgeBelow18_WhenPredicateDelegateIsCalled_ThenDelegateReturnsFalseForUnderAge()
        {
            Predicate<int> delegateResult = PD.CheckIfAdult;
            bool result = delegateResult(12);

            Assert.AreEqual(false, result);
        }
    }
}
