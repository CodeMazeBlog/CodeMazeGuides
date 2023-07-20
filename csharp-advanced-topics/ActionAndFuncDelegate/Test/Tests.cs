namespace Test
{

    [TestClass]
    public class Tests
    {
        static void PrintFullName(string gender, string firstName, string lastName)
        {
            Console.WriteLine("Full Name is : {0} {1} {2}", gender, firstName, lastName);
        }

        static int GetSum(int x, int y)
        {
            return (x + y);
        }


        [TestMethod]
        public void WhenActionDelegateExecutes_InvocationListIsNotEmpty()
        {
            Action<string, string, string> ActPrintName = PrintFullName;
            var invocationListLength = ActPrintName.GetInvocationList().Length;
            Assert.AreEqual(1, invocationListLength);
        }

        [TestMethod]
        public void WhenFuncDelegateExecutes_InvocationListIsNotEmpty()
        {
            Func<int, int, int> FuncSum = GetSum;
            var invocationListLength = FuncSum.GetInvocationList().Length;
            Assert.AreEqual(1, invocationListLength);
        }


        [TestMethod]
        public void WhenFuncDelegateExecutes_SumIsCorrect()
        {
            Func<int, int, int> FuncSum = GetSum;
            var result = FuncSum(2, 3);
            Assert.AreEqual((2+3), result);
        }
    }
}