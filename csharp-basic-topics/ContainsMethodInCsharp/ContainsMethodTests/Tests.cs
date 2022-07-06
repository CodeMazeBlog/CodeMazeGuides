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
            var exists = false;
            var countries = new string[] { "USA", "England", "Germany", "Sweden", "Poland" };

            exists = countries.Contains("Sweden") ? true : false;

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void WhenStringValueExistInStringArray_ThenReturnStringValueOfExistedElement()
        {
            var articles = new string[] { "article-1", "article-2", "article-3", "article-4", "article-5" };

            var results = from article in articles
                          where article.Contains("article-1")
                          select article;

            foreach (var result in results)
            {
                Assert.AreEqual("article-1", result);
            }
        }

        [TestMethod]
        public void WhenGivenStringValueExistInText_ThenReturnTupleAsStarterPositionOfValueAndBooleanValue()
        {
            var result = find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public void WhenAnyOfElementsMatchTheCondition_ThenReturnTrue()
        {
            var cities = new string[] { "Paris", "Tokyo", "Jakarta", "Delhi", "Mumbai" };

            var result1 = cities.Any(city => city.Contains("Tokyo", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void WhenAllOfElemenstMatchTheCondition_ThenReturnTrue()
        {
            Employee[] employees = new Employee[]
            {
                new () {Name = "James", Surname = "Smith", Age = 25},
                new () {Name = "Michael", Surname = "Smith", Age = 26},
                new () {Name = "Robert", Surname = "Smith", Age = 27},
                new () {Name = "David", Surname = "Smith", Age = 28},
                new () {Name = "Mary", Surname = "Smith", Age = 29}
            };

            var result2 = false;

            foreach (var employee in employees)
            {
                result2 = employee.Surname.Contains("Smith", StringComparison.InvariantCultureIgnoreCase);
                Assert.IsTrue(result2);
            }
        }

        static (int, bool) find(string givenString, string templateText)
        {
            int found = -1;
            var founded = false;
            int givenStringIndex = 0;

            for (int textIndex = 0; textIndex < templateText.Length; textIndex++)
            {
                if (givenString[givenStringIndex] == templateText[textIndex])
                {
                    if (givenStringIndex == 0)
                        found = textIndex;

                    givenStringIndex++;
                    if (givenStringIndex >= givenString.Length)
                    {
                        founded = true;
                        return (found, founded);
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

    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}