using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDelegate;

namespace ActionFuncDelegateUnitTest
{
    [TestClass]
    public class ActionFuncDelegateUnitTest
    {
        [TestMethod]
        public void TestMethod_Delegate1()
        {
            Program pm = new Program();
            string result = Program.Delegate1("Hello");
            Assert.AreEqual(result, "Hello");
        }
        [TestMethod]
        public void TestMethod_ActionDelegate()
        {
            Program pm = new Program();
            string result = Program.ActionDelegate("Good Morning");
            Assert.AreEqual(result, "Good Morning");
        }
        [TestMethod]
        public void TestMethod_AnonActionDelegate()
        {
            Program pm = new Program();
            string result = Program.AnonActionDelegate("Hello, Code Maze!");
            Assert.AreEqual(result, "Hello, Code Maze!");
        }
        [TestMethod]
        public void TestMethod_FuncDelegate()
        {
            Program pm = new Program();
            int result = Program.FuncDelegate(10, 5);
            Assert.AreEqual(result, 15);
        }
        [TestMethod]
        public void TestMethod_Delegate2()
        {
            Program pm = new Program();
            int result = Program.Delegate2(8, 5);
            Assert.AreEqual(result, 13);
        }
        [TestMethod]
        public void TestMethod_AnonFuncDelegate()
        {
            Program pm = new Program();
            int result = Program.FuncDelegate(3, 7);
            Assert.AreEqual(result, 10);
        }
    }
}