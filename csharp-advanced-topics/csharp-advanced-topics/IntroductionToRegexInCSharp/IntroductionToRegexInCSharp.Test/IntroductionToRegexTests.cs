using System.Text.RegularExpressions;
using Xunit;

namespace IntroductionToRegexInCSharp.Test
{
    public class IntroductionToRegexTests
    {
        [Fact]
        public void WhenUsingSimpleRegex_ThenIsMatch()
        {
            var regex = new Regex("a");
            var isMatch = regex.IsMatch("Learn C# language");

            Assert.True(isMatch);
        }

        [Fact]
        public void WhenUsingSimpleRegex_ThenMatchesCount()
        {
            var regex = new Regex("a");
            var matches = regex.Matches("Learn C# language");

            Assert.Equal(3, matches.Count);
        }

        [Fact]
        public void WhenUsingRegexAnchors_ThenMatchEntireString()
        {
            var regex = new Regex("^hello$");
            var isMatch = regex.IsMatch("hello");
            Assert.True(isMatch);

            isMatch = regex.IsMatch("hello world");
            Assert.False(isMatch);
        }

        [Fact]
        public void WhenUsingCharacterClasses_ThenMatchOnlyDigits()
        {
            var regex = new Regex(@"\d");
            var matches = regex.Matches(@"9841 Shadow Way St
                                        Sunland, California(CA)");

            Assert.Equal(4, matches.Count);
            Assert.Equal("9", matches[0].Value);
            Assert.Equal("8", matches[1].Value);
            Assert.Equal("4", matches[2].Value);
            Assert.Equal("1", matches[3].Value);
        }

        [Fact]
        public void WhenUsingQuantifiers_ThenMatchOneOrMoreNumbers()
        {
            var regex = new Regex(@"\d+");
            var match = regex.Match(@"9841 Shadow Way St
                                        Sunland, California(CA)");

            Assert.Equal("9841", match.Value);
        }

        [Fact]
        public void WhenUsingASet_ThenMatchOneOfTheElements()
        {
            var regex = new Regex("[sg]old");
            var matches = regex.Matches("sold cold gold");

            Assert.Equal(2, matches.Count);
            Assert.Equal("sold", matches[0].Value);
            Assert.Equal("gold", matches[1].Value);
        }

        [Fact]
        public void WhenUsingRange_ThenMatchAllElementsIncluded()
        {
            var regex = new Regex("[a-d]+");
            var match = regex.Match("abcdefghi");

            Assert.Equal("abcd", match.Value);
        }

        [Fact]
        public void WhenUsingExclusionRange_ThenMatchNoneOfTheElementsIncluded()
        {
            var regex = new Regex("[^a-d]+");
            var match = regex.Match("abcdefghi");

            Assert.Equal("efghi", match.Value);
        }

        [Fact]
        public void WhenUsingCaptureGroups_ThenExtractsDefiningGroups()
        {
            var regex = new Regex(@"^(\w+)\.(\w{3})$");
            var match = regex.Match("test_file_name.txt");

            Assert.Equal("test_file_name", match.Groups[1].Value);
            Assert.Equal("txt", match.Groups[2].Value);
        }

        [Fact]
        public void WhenUsingReplace_ThenAllOccurencesAreReplaced()
        {
            var regex = new Regex(@"</?\w+>");
            var result = regex.Replace("<b>Hello, <i>world</i></b>", string.Empty);

            Assert.Equal("Hello, world", result);
        }
    }
}