using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnsafeCodeInCSharp.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenPointerVariablePassedThenValueTriples()
        {
            unsafe
            {
                int input = 30;
                int* ptr = &input;

                Program.GetTriple(ptr);

                Assert.AreEqual(90, input);
            }
        }
    }
}