using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticVsNonStaticMethodsInCsharp;

namespace StaticVsNonStaticMethodsTests
{
    [TestClass]
    public class Tests
    {
        StaticVsNonStaticMethods staticVsNonStatic = new StaticVsNonStaticMethods();

        [TestMethod]
        public void GivenTwoNumbers_ThenReturnAdditionOfThem()
        {
            var result = staticVsNonStatic.Addition(10, 5);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void GivenTwoNumbers_ThenReturnDivisionOfThem()
        {
            var result = StaticVsNonStaticMethods.Division(10, 5);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void WhenExecuteTheStaticMethod_ThenDoTheIncrementOperation()
        {
            int result = StaticVsNonStaticMethods.IncrementNumber();
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenFindItWithExtensionMethod()
        {
            var words = new string[] { "article-1", "article-2", "article-3", "article-4", "article-5" };
            int index = words.FindSearchedElementIndex("article-3");

            Assert.AreEqual(2, index);
        }
    }
}