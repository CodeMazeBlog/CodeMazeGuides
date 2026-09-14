using System.Globalization;
using CaseInsensitiveSubstringSearch;

namespace Tests
{
    [TestClass]
    public class SubstringSearchSemanticsTest
    {
        private const string SourceString = "Code Maze";

        [TestMethod]
        [DataRow("aze")]
        [DataRow("ode")]
        [DataRow("e M")]
        public void GivenMidWordSubstring_WhenComparingAllFiveMethods_ThenOnlyLinqStringEqualsReturnsFalse(string subStringToSearch)
        {
            Assert.IsTrue(SubstringSearch.StringContains(SourceString, subStringToSearch));
            Assert.IsTrue(SubstringSearch.StringIndexOf(SourceString, subStringToSearch));
            Assert.IsTrue(SubstringSearch.StringToUpperInvariant(SourceString, subStringToSearch));
            Assert.IsTrue(SubstringSearch.RegexIsMatch(SourceString, subStringToSearch));

            Assert.IsFalse(SubstringSearch.LinqStringEquals(SourceString, subStringToSearch, ' '));
        }

        [TestMethod]
        [DataRow("c.de")]
        [DataRow("z*")]
        [DataRow("m|q")]
        [DataRow("(")]
        public void GivenSearchTermHoldingRegexMetacharacters_WhenUsingRegexIsMatchMethod_ThenItAgreesWithStringContains(string subStringToSearch)
        {
            var expectedResult = SubstringSearch.StringContains(SourceString, subStringToSearch);

            var result = SubstringSearch.RegexIsMatch(SourceString, subStringToSearch);

            Assert.AreEqual(expectedResult, result);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTurkishCulture_WhenSearchingForFileInsideFILE_ThenAllFourContainmentMethodsMatch()
        {
            var originalCulture = CultureInfo.CurrentCulture;

            try
            {
                CultureInfo.CurrentCulture = new CultureInfo("tr-TR");

                Assert.IsTrue(SubstringSearch.StringContains("FILE", "file"));
                Assert.IsTrue(SubstringSearch.StringIndexOf("FILE", "file"));
                Assert.IsTrue(SubstringSearch.StringToUpperInvariant("FILE", "file"));
                Assert.IsTrue(SubstringSearch.RegexIsMatch("FILE", "file"));
            }
            finally
            {
                CultureInfo.CurrentCulture = originalCulture;
            }
        }
    }
}
