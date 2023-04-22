using StringReverse;
using System.Reflection;

namespace StrinReverseUnitTest
{
    [TestClass]
    public class StringReverseUnitTest
    {
        private readonly string _input = "abcdef";
        private readonly string _expected = "fedcba";
        private readonly string _inputEmpty = string.Empty;
        private readonly string _expectedEmpty = string.Empty;

        [TestMethod]
        public void GivenMethodArrayReverse_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.ArrayReverseString(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodArrayReverse_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.ArrayReverseString(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodEnumerableReverse_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.EnumerableReverseMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodEnumerableReverse_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.EnumerableReverseMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodRecursiveString_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.RecursiveStringReverseMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodRecursiveString_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.RecursiveStringReverseMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodReverseXorMethod_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.ReverseXorMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodReverseXorMethod_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.ReverseXorMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodStackReverse_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.StackReverseMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodStackReverse_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.StackReverseMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodStringBuilderReverse_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.StringBuilderReverseMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodStringBuilderReverse_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.StringBuilderReverseMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodStringCreate_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.StringCreateMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodStringCreate_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.StringCreateMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }

        [TestMethod]
        public void GivenMethodStringExtension_WhenAbcdef_Thenfedcba()
        {
            var result = Methods.StringExtensionReverseMethod(_input);
            Assert.AreEqual(_expected, result);
        }

        [TestMethod]
        public void GivenMethodStringExtension_WhenStringEmpty_ThenStringEmpty()
        {
            var result = Methods.StringExtensionReverseMethod(_inputEmpty);
            Assert.AreEqual(_expectedEmpty, result);
        }
    }
}