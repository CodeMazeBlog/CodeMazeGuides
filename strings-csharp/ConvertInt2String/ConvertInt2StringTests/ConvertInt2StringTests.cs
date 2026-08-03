using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ConvertInt2StringTests
{
    [TestClass]
    public class ConvertInt2StringTests
    {
        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodToString_ThenReturnString()
        {
            var num = 3;
            var str = num.ToString();

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodConvertToString_ThenReturnString()
        {
            var num = 3;
            var str = System.Convert.ToString(num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodStringFormat_ThenReturnString()
        {
            var num = 3;
            var str = string.Format("{0}", num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithStringInterpolation_ThenReturnString()
        {
            var num = 3;
            var str = $"{num}";

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodStringConcat_ThenReturnString()
        {
            var num = 3;
            var str = string.Concat(string.Empty, num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodStringJoin_ThenReturnString()
        {
            var num = 3;
            var str = string.Join(string.Empty, num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithPlusSignConcatenation_ThenReturnString()
        {
            var num = 3;
            var str = string.Empty + num;

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithStringBuilderAppend_ThenReturnString()
        {
            var num = 3;
            var str = new StringBuilder().Append(num).ToString();

            Assert.AreEqual("3", str);
        }
    }
}