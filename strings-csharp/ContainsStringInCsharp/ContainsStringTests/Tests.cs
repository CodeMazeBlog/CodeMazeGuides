using ContainsString;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ContainsStringTests
{
    [TestClass]
    public class Tests
    {
        FindStringExamples findStringExamples = new FindStringExamples();

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnBooleanValue()
        {
            var exists = findStringExamples.ContainsCountry();
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnStringValueOfExistedElement()
        {
            var result = findStringExamples.ContainsArticle();
            Assert.AreEqual("article-1", result);
        }

        [TestMethod]
        public void WhenGivenStringValueExistInText_ThenReturnTupleAsStarterPositionOfValueAndBooleanValue()
        {
            
            var result = findStringExamples.Find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void WhenAnyOfElementsMatchTheCondition_ThenReturnTrue()
        {
            var result = findStringExamples.ContainsCity();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAllOfElemenstMatchTheCondition_ThenReturnTrue()
        {
            var results = findStringExamples.ContainsNameInEmployees();

            foreach (var result in results)
            {
                Assert.IsTrue(result);
            }
        }
    }
}