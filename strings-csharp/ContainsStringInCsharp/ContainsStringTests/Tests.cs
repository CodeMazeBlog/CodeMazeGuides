using ContainsString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainsStringTests
{
    [TestClass]
    public class Tests
    {
        FindStringExamples findStringExamples = new FindStringExamples();

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnBooleanValue()
        {
            var result = findStringExamples.ContainsCountry();
            Assert.IsTrue(result);
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
        public void WhenAnyOfElementsMatchTheConditionWithCaseSensetive_ThenReturnTrue()
        {
            var result = findStringExamples.ContainsCityWithCaseSensetive();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAnyOfElementsDoNotMatchTheConditionWithoutCaseSensetive_ThenReturnFalse()
        {
            var result = findStringExamples.ContainsCityWithoutCaseSensetive();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenAllOfElemenstMatchTheCondition_ThenReturnTrue()
        {
            var result = findStringExamples.ContainsNameInEmployees();
            Assert.IsTrue(result);
        }
    }
}