using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnsafeCodeInCSharp.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenPointerVariablePassed_ThenValueTriples()
        {
            unsafe
            {
                var input = 30;
                int* inputPtr = &input;

                Program.GetTriple(inputPtr);

                Assert.AreEqual(90, input);
            }
        }
    }
}