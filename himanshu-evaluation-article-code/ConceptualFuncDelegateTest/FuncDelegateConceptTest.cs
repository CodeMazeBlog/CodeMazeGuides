using ConceptualFuncDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConceptualFuncDelegateTest
{
    [TestClass]
    public class FuncDelegateConceptTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FuncyMath foo = new FuncyMath();
            Func<int, int> funcFunctionPointer = foo.DoubleUp;
            int result = funcFunctionPointer(5);
            Assert.AreEqual(10, result);
        }
    }
}
