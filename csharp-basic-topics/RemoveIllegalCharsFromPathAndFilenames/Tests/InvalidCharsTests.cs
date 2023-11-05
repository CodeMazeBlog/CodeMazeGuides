using CodeMazeGuides.CSBasic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        // known invalid paths
        static List<string> TestCaseSearch = new List<string> 
            {
                "C://User/Test/Stuff/Invalid>>>><<<<--Chars",
                "D://User/iLikeToIncludeINVALIDChars/*/     z"
            };

        [Test]
        public void WhenGivenListOfStrings_ThenFindStringsWithInvalidChars()
        {
            var result = Program.GetInvalidPaths(TestCaseSearch);
            Assert.That(TestCaseSearch, Is.EqualTo(result));
        }

        [Test]
        public void WhenGivenlListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQ()
        {
            var result = Program.GetInvalidPathsLINQ(TestCaseSearch);
            Assert.That(TestCaseSearch, Is.EqualTo(result));
        }

        [Test]
        public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQHeaderFormat()
        {
            var result = Program.GetInvalidPathsLINQHeaderFormat(TestCaseSearch);
            Assert.That(TestCaseSearch, Is.EqualTo(result));
        }

        [Test]
        public void WhenGivenListOfStrings_thenFindStringsWithInvalidCharsUsingRegEx()
        {
            var result = Program.GetInvalidPathsRegEx(TestCaseSearch);
            Assert.That(TestCaseSearch,Is.EqualTo(result));
        }

        [TestCase("")]
        [TestCase("_")]
        public void WhenGivenInvalidPathList_ThenReplaceOrRemoveInvalidChars(string repChar)
        {
            var invalidChars = Path.GetInvalidPathChars().Concat(Path.GetInvalidFileNameChars()).ToArray();

            foreach (string path in TestCaseSearch)
            {
                var result = Program.ReplaceInvalidChars(path, repChar);

                if (result.Any(x => invalidChars.Contains(x)))
                {
                    Assert.Fail();                    
                }
            }

            Assert.Pass();
        }
    }
}