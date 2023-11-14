using FuncDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{

    [TestClass]
    public class FuncUnitTests
    {   
        
        [TestMethod]
        public void Given_FuncSampleWithAddMethod_When_ReceiveTwoIntegers_Then_Add()
        {
            Func<int, int, int> funcDelegate = FuncSample.Add;
            var result = funcDelegate(5, 8);
            
            Assert.AreEqual(13, result);

        }

        [TestMethod]
        public void Given_FuncSampleWithMultiplyMethod_When_ReceiveTwoIntegers_Then_Multiply()
        {
            Func<int, int, int> funcDelegate = FuncSample.Multiply;
            var result = funcDelegate(5, 8);
            
            Assert.AreEqual(40, result);
        }
    }
}