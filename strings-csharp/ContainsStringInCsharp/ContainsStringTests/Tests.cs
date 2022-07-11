using ContainsString;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ContainsStringTests
{
    [TestClass]
    public class Tests
    {
        Methods methods = new Methods();

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnBooleanValue()
        {
            var exists = methods.ContainsCountry();
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnStringValueOfExistedElement()
        {
            var result = methods.ContainsArticle();
            Assert.AreEqual("article-1", result);
        }

        [TestMethod]
        public void WhenGivenStringValueExistInText_ThenReturnTupleAsStarterPositionOfValueAndBooleanValue()
        {
            
            var result = methods.Find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void WhenAnyOfElementsMatchTheCondition_ThenReturnTrue()
        {
            var result = methods.ContainsCity();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAllOfElemenstMatchTheCondition_ThenReturnTrue()
        {
            var results = methods.ContainsNameInEmployees();

            foreach (var result in results)
            {
                Assert.IsTrue(result);
            }
        }
    }
}