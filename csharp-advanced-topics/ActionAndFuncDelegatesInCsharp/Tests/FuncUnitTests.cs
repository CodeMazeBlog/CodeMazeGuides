using FuncDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{

    [TestClass]
    public class FuncUnitTests
    {   
        
        [TestMethod]
        public void GivenFuncSampleWithAddMethod_WhenReceiveTwoIntegers_ThenAdd()
        {
            Func<int, int, int> funcDelegate = FuncSample.Add;
            var result = funcDelegate(5, 8);
            
            Assert.AreEqual(13, result);

        }

        [TestMethod]
        public void GivenFuncSampleWithMultiplyMethod_WhenReceiveTwoIntegers_ThenMultiply()
        {
            Func<int, int, int> funcDelegate = FuncSample.Multiply;
            var result = funcDelegate(5, 8);
            
            Assert.AreEqual(40, result);
        }
    }
}