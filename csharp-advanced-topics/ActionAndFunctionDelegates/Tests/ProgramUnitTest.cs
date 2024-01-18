namespace Tests
{
    delegate int MathDelegate(int num1, int num2);
    delegate void TextDelegate(string str);

    public class ProgramUnitTest
    {
        private static int Max(int var1, int var2) { return var1 > var2 ? var1 : var2; }
        private static void Print(string str) { Console.WriteLine(str); }
        private static int DelegateCaller(int var1, int var2, MathDelegate delegate1) { return delegate1(var1, var2); }

        [Fact]
        public void WhenIntegersIsSentToDelegate_DelegateReturnMax()
        {
            var delegate1 = new MathDelegate(Max);
            var result = delegate1(2, 6);

            Assert.Equal(6, result);
        }

        [Fact]
        public void WhenAssignPrintMethodToDelegate_JustPrintMethodWillInvoked()
        {
            var delegate1 = new TextDelegate(Print);
            var invocationList = delegate1.GetInvocationList();

            Assert.Single(invocationList);
            Assert.Equal("Print", invocationList[0].Method.Name);
        }
        [Fact]
        public void WhenMathDelegateIsSentToDelegateCaller_MathDelegateIsInvoked()
        {
            var delegate1 = new MathDelegate(Max);
            var result = DelegateCaller(0, 1, delegate1);

            Assert.Equal(1, result);
        }
        [Fact]
        public void WhenMaxMethodAssignedToFunc_FuncReturnTheMax()
        {
            Func<int, int, int> MaxFunc = Max;
            var result = MaxFunc(-20, 10);

            Assert.Equal(10, result);
        }

        [Fact]
        public void WhenAssignPrintMethodToActione_JustPrintMethodWillInvoke()
        {
            Action<string> PrintAction = Print;
            var invocationList = PrintAction.GetInvocationList();

            Assert.Single(invocationList);
            Assert.Equal("Print", invocationList[0].Method.Name);
        }
    }
}