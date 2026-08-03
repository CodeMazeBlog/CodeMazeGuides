using CaseInsensitiveSubstringSearch;

namespace Tests
{
    [TestClass]
    public class SubstringSearchUnitTest
    {
        [TestMethod]
        [DataRow("Code Maze", "Maze", true)]
        [DataRow("Code Maze", "maze", true)]
        [DataRow("Code Maze", "zame", false)]
        public void GivenSourceAndSubstring_WhenUsingStringContainsMethod_ThenShouldReturnContainmentResult(string sourceString, string subStringToSearch, bool expectedResult)
        {
            var result = SubstringSearch.StringContains(sourceString, subStringToSearch);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("Code Maze", "Maze", true)]
        [DataRow("Code Maze", "maze", true)]
        [DataRow("Code Maze", "zame", false)]
        public void GivenSourceAndSubstring_WhenUsingStringIndexOfMethod_ThenShouldReturnContainmentResult(
            string sourceString, string subStringToSearch, bool expectedResult)
        {
            var result = SubstringSearch.StringIndexOf(sourceString, subStringToSearch);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("Code Maze", "Maze", true)]
        [DataRow("Code Maze", "maze", true)]
        [DataRow("Code Maze", "zame", false)]
        public void GivenSourceAndSubstring_WhenUsingStringToUpperInvariantMethod_ThenShouldReturnContainmentResult(
            string sourceString, string subStringToSearch, bool expectedResult)
        {
            var result = SubstringSearch.StringToUpperInvariant(sourceString, subStringToSearch);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("Code Maze", "Maze", true)]
        [DataRow("Code Maze", "maze", true)]
        [DataRow("Code Maze", "zame", false)]
        public void GivenSourceAndSubstring_WhenUsingRegexIsMatchMethod_ThenShouldReturnContainmentResult(
            string sourceString, string subStringToSearch, bool expectedResult)
        {
            var result = SubstringSearch.RegexIsMatch(sourceString, subStringToSearch);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("Code Maze", "Maze", ' ', true)]
        [DataRow("Code Maze", "maze", ' ', true)]
        [DataRow("Code Maze", "zame", ' ', false)]
        public void GivenSourceSubstringAndSeparator_WhenUsingLinqStringEqualsMethod_ThenShouldReturnContainmentResult(
            string sourceString, string subStringToSearch, char separator, bool expectedResult)
        {
            var result = SubstringSearch.LinqStringEquals(sourceString, subStringToSearch, separator);

            Assert.AreEqual(expectedResult, result);
        }
    }
}