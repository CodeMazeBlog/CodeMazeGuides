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
            int num = 3;
            string str = num.ToString();

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodConvertToString_ThenReturnString()
        {
            int num = 3;
            string str = System.Convert.ToString(num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodStringFormat_ThenReturnString()
        {
            int num = 3;
            string str = string.Format("{0}", num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithStringInterpolation_ThenReturnString()
        {
            int num = 3;
            string str = $"{num}";

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodStringConcat_ThenReturnString()
        {
            int num = 3;
            string str = string.Concat(string.Empty, num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithMethodStringJoin_ThenReturnString()
        {
            int num = 3;
            string str = string.Join(string.Empty, num);

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithPlusSignConcatenation_ThenReturnString()
        {
            int num = 3;
            string str = string.Empty + num;

            Assert.AreEqual("3", str);
        }

        [TestMethod]
        public void GivenInt_WhenConvertedToStringWithStringBuilderAppend_ThenReturnString()
        {
            int num = 3;
            string str = new StringBuilder().Append(num).ToString();

            Assert.AreEqual("3", str);
        }
    }
}