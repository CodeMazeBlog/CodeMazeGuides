using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DebuggingBasicsInCSharp.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenNumberIsPassedThenReturnMultiplicationTable()
        {
            var number = 7;

            var actual = Program.GetMultiplicationTable(number);

            Assert.IsNotNull(actual);

            StringAssert.Contains(actual, "7 X 1 = 7");
        }
    }
}