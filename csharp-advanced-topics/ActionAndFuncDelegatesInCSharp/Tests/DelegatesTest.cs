namespace Tests
{
    [TestClass]
    public class DelegatesTest
    {
        public static string actionResult = "";
        public static string Multiply(int a, int b) { return $"Multiplication Result : {a * b}"; }
        public static string Add(int a, int b) { return $"Addition Result : {a + b}"; }
        public static string Divide(int a, int b) { return $"Division Result : {a / b}"; }
        public static string Subtract(int a, int b) { return $"Subtraction Result : {a - b}"; }
        public static void PrintMultiplyResult(int a, int b) { actionResult = $"Print my Multiplication Result : {a * b}"; }
        public static bool CheckIfAdult(int age) { return age > 18 ? true : false; }

        [TestMethod]
        public void GivenMultiplyMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsAMultipliedResult()
        {
            Func<int, int, string> delegateResult = Multiply;
            var result = delegateResult(5,5);

            Assert.AreEqual("Multiplication Result : 25", result);
        }

        [TestMethod]
        public void GivenAdditionMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsAMultipledResult()
        {
            Func<int, int, string> delegateResult = Add;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Addition Result : 10", result);
        }

        [TestMethod]
        public void GivenDivisionMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsADividedResult()
        {
            Func<int, int, string> delegateResult = Divide;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Division Result : 1", result);
        }

        [TestMethod]
        public void GivenSubtractionMethod_WhenFuncDelegateIsCalled_ThenDelegateReturnsASubtractedResult()
        {
            Func<int, int, string> delegateResult = Subtract;
            var result = delegateResult(5, 5);

            Assert.AreEqual("Subtraction Result : 0", result);
        }

        [TestMethod]
        public void GivenTwoIntegers_WhenActionDelegateIsCalledToMultipy_ThenDelegatePrintsMultipliedResult()
        {
            Action<int, int> delegateResult = PrintMultiplyResult;
            delegateResult(5, 5);

            Assert.AreEqual("Print my Multiplication Result : 25", actionResult);
        }

        [TestMethod]
        public void GivenAnAgeBelow18_WhenPredicateDelegateIsCalled_ThenDelegateReturnsFalseForUnderAge()
        {
            Predicate<int> delegateResult = CheckIfAdult;
            bool result = delegateResult(12);

            Assert.AreEqual(false, result);
        }
    }
}
