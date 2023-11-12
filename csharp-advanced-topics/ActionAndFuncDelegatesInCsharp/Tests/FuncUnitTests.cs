using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{

    [TestClass]
    public class FuncUnitTests
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }
        
        [TestMethod]
        public void WhenRecieveTwoIntegers_Add()
        {
            Func<int, int, int> funcDelegate = Add;
            int result = funcDelegate(5, 8);
            Assert.AreEqual(13, result);

        }

        [TestMethod]
        public void WhenRecieveTwoIntegers_Multiply()
        {
            Func<int, int, int> funcDelegate = Multiply;
            int result = funcDelegate(5, 8);
            Assert.AreEqual(40, result);
        }
    }
}