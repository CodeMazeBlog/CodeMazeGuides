using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class FuncTests
    {

        [TestMethod]
        public void WhenPassingStringToFuncThenStringIsCapitalized()
        {
            string Capitalize(string s)
            {
                return s.ToUpper();
            }
            var capitalizeFunc = new Func<string, string>(Capitalize);
            var result = capitalizeFunc("hello world");
            Assert.AreEqual(result, "hello world".ToUpper());
        }

        [TestMethod]
        public void WhenPassingStringToAnonymousFuncThenStringIsCapitalized()
        {
            var capitalizeAnonymousFunc = new Func<string, string>((s) => s.ToUpper());
            var result = capitalizeAnonymousFunc("hello world");
            Assert.AreEqual(result, "hello world".ToUpper());
        }
    }
}
