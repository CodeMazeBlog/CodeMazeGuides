using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertCharArray2StringTests
{
    [TestClass]
    public class ConvertCharArrayTests
    {
        [TestMethod]
        public void GivenCharArray_WhenConvertedByConstructor_ThenReturnString()
        {
            char[] charArray = { 'c', 'o', 'd', 'e', ' ', 'm', 'a', 'z', 'e' };

            var convertedToString = new string(charArray);
            
            Assert.AreEqual("code maze", convertedToString);
        }

        [TestMethod]
        public void GivenCharArray_WhenConvertedByJoin_ThenReturnString()
        {
            char[] charArray = { 'c', 'o', 'd', 'e', ' ', 'm', 'a', 'z', 'e' };

            var joinedToString = string.Join("", charArray);

            Assert.AreEqual("code maze", joinedToString);
        }

        [TestMethod]
        public void GivenCharArray_WhenConvertedByConcat_ThenReturnString()
        {
            char[] charArray = { 'c', 'o', 'd', 'e', ' ', 'm', 'a', 'z', 'e' };

            var concatedToString = string.Concat(charArray);

            Assert.AreEqual("code maze", concatedToString);
        }
    }
}