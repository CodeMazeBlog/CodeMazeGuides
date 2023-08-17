using PerformSubstringSearchWithContainsMethod;

namespace Tests
{
    [TestClass]
    public class StringSearchUnitTest
    {
        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingStringContainsMethod_ThenShouldReturnContainmentResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.StringContainsSubstringWithNoParameter(sourceString, substringToSearch);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingStringContainsMethodWithOrdinal_ThenShouldReturnContainmentResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.StringContainsSubstringWithOrdinalStringComparisonParameter(sourceString, substringToSearch);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingStringContainsMethodWithIgnoreCase_ThenShouldReturnContainmentResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.StringContainsSubstringWithOrdinalIgnoreCaseStringComparisonParameter(sourceString, substringToSearch);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingStringIndexOfMethod_ThenShouldReturnIndexSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.StringIndexOfMethodSearchWithNoParameter(sourceString, substringToSearch);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingStringIndexOfMethodWithOrdinal_ThenShouldReturnIndexSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.StringIndexOfMethodSearchWithOrdinalStringComparisonParameter(sourceString, substringToSearch);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingStringIndexOfMethodWithIgnoreCase_ThenShouldReturnIndexSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.StringIndexOfMethodSearchWithOrdinalIgnoreCaseStringComparisonParameter(sourceString, substringToSearch);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingRegularExpressionSearch_ThenShouldReturnRegexSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.RegularExpressionSearchWithNoParameter(sourceString, substringToSearch);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingRegularExpressionSearchWithOptionsNone_ThenShouldReturnRegexSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.RegularExpressionSearchWithRegexOptionsNoneParameter(sourceString, substringToSearch);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstring_WhenUsingRegularExpressionSearchWithIgnoreCase_ThenShouldReturnRegexSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var result = SubstringSearch.RegularExpressionSearchWithRegexOptionsIgnoreCaseParameter(sourceString, substringToSearch);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstringAndSeparator_WhenUsingLinqWithStringEqualsMethod_ThenShouldReturnLinqSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var separator = ' ';
            var result = SubstringSearch.LinqWithStringEqualsMethodSearchWithNoParameter(sourceString, substringToSearch, separator);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstringAndSeparator_WhenUsingLinqWithStringEqualsMethodWithOrdinal_ThenShouldReturnLinqSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var separator = ' ';
            var result = SubstringSearch.LinqWithStringEqualsMethodSearchWithOrdinalStringComparisonParameter(sourceString, substringToSearch, separator);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSourceAndSubstringAndSeparator_WhenUsingLinqWithStringEqualsMethodWithIgnoreCase_ThenShouldReturnLinqSearchResult()
        {
            var sourceString = "Code Maze";
            var substringToSearch = "maze";
            var separator = ' ';
            var result = SubstringSearch.LinqWithStringEqualsMethodSearchWithOrdinalIgnoreCaseStringComparisonParameter(sourceString, substringToSearch, separator);

            Assert.IsTrue(result);
        }
    }
}