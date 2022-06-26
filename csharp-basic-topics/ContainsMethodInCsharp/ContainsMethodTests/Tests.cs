using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ContainsMethodTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnBooleanValue()
        {
            var isExist = false;
            var countries = new string[] { "USA", "England", "Germany", "Sweeden", "Poland" };

            if (countries.Contains("Sweeden"))
                isExist = true;
            else
                isExist = false;

            Assert.IsTrue(isExist);
        }

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnStringValueOfExistedElement()
        {
            var articles = new string[] { "article-1", "article-2", "article-3", "article-4", "article-5" };

            var isFounded = from article in articles
                            where article.Contains("article-1")
                            select article;

            foreach (var found in isFounded)
            {
                Assert.AreEqual("article-1", found);
            }
        }

        [TestMethod]
        public void WhenGivenStringValueExistInText_ThenReturnTupleAsStarterPositionOfValueAndBooleanValue()
        {
            var result = find("Code-Maze", "If you want to read great articles, then let's check the Code-Maze.");
            Assert.IsTrue(result.Item2);
        }

        static (int, bool) find(string givenString, string templateText)
        {
            int found = -1;
            var isFound = false;
            int givenStringIndex = 0;

            if (String.IsNullOrEmpty(givenString) || string.IsNullOrEmpty(templateText))
                return (-1, false);

            for (int textIndex = 0; textIndex < templateText.Length; textIndex++)
            {
                if (givenString[givenStringIndex] == templateText[textIndex])
                {
                    if (givenStringIndex == 0)
                        found = textIndex;

                    givenStringIndex++;
                    if (givenStringIndex >= givenString.Length)
                    {
                        isFound = true;
                        return (found, isFound);
                    }
                }
                else
                {
                    givenStringIndex = 0;
                    if (found >= 0)
                        textIndex = found;
                    found = -1;
                }
            }
            return (-1, false);
        }
    }
}