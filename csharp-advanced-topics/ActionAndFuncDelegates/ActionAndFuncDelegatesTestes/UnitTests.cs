namespace ActionAndFuncDelegatesTestes
{
    public delegate void ShowPersonData(double salary);

    public delegate string PerformUpper(string name, int age);

    [TestClass]
    public class UnitTests
    {
        void Print(double salary) => Console.WriteLine(salary);

        string UppercaseString(string strName, int age) { return (strName + "-" + age).ToUpper(); }

        [TestMethod]
        public void WhenInvokeADelegateWitchReceiveANamedMethod_ThenCheckIfContainsAMethod()
        {
            var delegateTest = new ShowPersonData(Print);

            var delegateMethod = delegateTest.Method;

            Assert.AreEqual(delegateMethod.Name, "Print");
        }

        [TestMethod]
        public void WhenInvokeADelegateWitchReceiveANamedMethodThatReturnsAValue_ThenReturnAValue()
        {
            var delegateTest = new PerformUpper(UppercaseString);

            var res = delegateTest("Justin", 27);

            Assert.AreEqual(res, "JUSTIN-27");
        }

        [TestMethod]
        public void WhenInvokeAnActionWitchReceiveALambdaExpression_ThenPerformTheLambdaOperation()
        {
            string fName = "";
            string lName = "";

            Action<string, string> showFullName = (string fuName, string laName) =>
            {
                fName = fuName;
                lName = laName;
            };

            showFullName("Justino", "Sachilombo");

            Assert.AreEqual(fName, "Justino");
            Assert.AreEqual(lName, "Sachilombo");
        }

        [TestMethod]
        public void WhenInvokeAFuncWitchReceiveALambdaExpression_ThenReturnAValue()
        {
            Func<string, string> mySelector = str => str.ToUpper();

            var res = mySelector("Justino");

            Assert.AreEqual(res, "JUSTINO");
        }

        [TestMethod]
        public void WhenInvokeAFuncWitchReceiveAMethodWithTwoInputParams_ThenReturnAValue()
        {
            Func<string, int, string> upperFunc = UppercaseString;

            var res = upperFunc("mArIa", 27);

            Assert.AreEqual(res, "MARIA-27");
        }
    }
}