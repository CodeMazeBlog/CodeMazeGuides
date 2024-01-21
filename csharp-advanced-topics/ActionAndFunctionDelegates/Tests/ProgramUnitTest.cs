using ActionAndFunctionDelegates;

namespace Tests
{
    public class ProgramUnitTest
    {
        [Fact]
        public void WhenMaxMethodAssignedToMathDelegateInstance_ThenInstanceReturnTheMaxOfItsParameters()
        {
            var delegate1 = new MathDelegate(Program.Max);
            var result = delegate1(2, 6);

            Assert.Equal(6, result);
        }

        [Fact]
        public void WhenPrintMethodAssignedToTextDelegateInstance_ThenInstanceWillInvokJustPrintMethod()
        {
            var delegate1 = new TextDelegate(Program.Print);
            var invocationList = delegate1.GetInvocationList();

            Assert.Single(invocationList);
            Assert.Equal("Print", invocationList[0].Method.Name);
        }
        [Fact]
        public void WhenWrappedMaxFunctionSentToDelegateCaller_ThenDelegateCallerReturnMaxOfItsIntegerParameters()
        {
            var delegate1 = new MathDelegate(Program.Max);
            var result = Program.DelegateCaller(0, 1, delegate1);

            Assert.Equal(1, result);
        }
        [Fact]
        public void WhenMaxMethodAssignedToFunc_ThenFuncReturnTheMaxOfItsParameters()
        {
            Func<int, int, int> MaxFunc = Program.Max;
            var result = MaxFunc(-20, 10);

            Assert.Equal(10, result);
        }

        [Fact]
        public void WhenPrintMethodAssignedToAction_ThenJustPrintMethodInvoked()
        {
            Action<string> PrintAction = Program.Print;
            var invocationList = PrintAction.GetInvocationList();

            Assert.Single(invocationList);
            Assert.Equal("Print", invocationList[0].Method.Name);
        }
    }
}