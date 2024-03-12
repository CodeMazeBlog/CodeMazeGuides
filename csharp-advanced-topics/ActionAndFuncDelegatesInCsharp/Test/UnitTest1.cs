using ActionAndFuncDelegatesInCsharp.Action;
using ActionAndFuncDelegatesInCsharp.Func;

namespace Test
{
    [TestClass]
    public class ActionAndFuncDelatesTests
    {
        #region Action Test
        [TestMethod]
        public void TestActionDelegate()
        {
            ActionDelegate actionDelegate = new ActionDelegate();
            actionDelegate.Action_PrintNumber(new Random().Next(int.MinValue, int.MaxValue));
        }

        [TestMethod]
        public void TestActionMethodName()
        {
            ActionDelegate actionDelegate = new ActionDelegate();
            Action<int> ActionUsingNameMethod = actionDelegate.Action_NamedMethod_Example;

            ActionUsingNameMethod(new Random().Next(int.MinValue, int.MaxValue));
        }
        #endregion

        #region Func Test
        [TestMethod]
        public void TestFuncDelegate()
        {
            FuncDelegate funcDelegate = new FuncDelegate();
            int n1 = new Random().Next(int.MinValue, int.MaxValue);
            int n2 = new Random().Next(int.MinValue, int.MaxValue);

            funcDelegate.Func_Sum(n1, n2);
        }

        [TestMethod]
        public void TestFuncMethodName()
        {
            FuncDelegate funcDelegate = new FuncDelegate();
            Func<int, int, int> funcUsingNamedMethod = funcDelegate.Func_NamedMethod_Example;

            int n1 = new Random().Next(int.MinValue, int.MaxValue);
            int n2 = new Random().Next(int.MinValue, int.MaxValue);

            funcUsingNamedMethod(n1, n2);
        }
        #endregion
    }
}