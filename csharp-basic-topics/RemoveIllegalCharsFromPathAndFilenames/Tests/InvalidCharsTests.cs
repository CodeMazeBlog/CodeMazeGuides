namespace Tests;

public class InvalidCharactersTests
{
    private static readonly IEnumerable<string> TestCaseSearch = new List<string> 
    {
        "C://User/Test/Stuff/Invalid>>>>?||?<<<<-\u0015-Chars",
        "D://User/iLi?||?keToIncludeINVALIDChars/*/ \u0015    z"
    };

    private static readonly IEnumerable<string> TestCaseFilenames = new List<string>
    {
        "A://ValidPath/SomeFolder/Invalid??File??Broken.nah",
        "I://ProgramFiles/SomeApplication/:Invalid:Filename.txt"
    };

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidChars()
    {
        var result = StringMethods.CheckForInvalid(TestCaseSearch, StringConstants.InvalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }

    [Test]
    public void WhenGivenlListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQ()
    {
        var result = StringMethods.CheckForInvalidLINQ(TestCaseSearch, StringConstants.InvalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQQuerySyntax()
    {
        var result = StringMethods.CheckForInvalidLINQQuerySyntax(TestCaseSearch, StringConstants.InvalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingRegEx()
    {
        var result = StringMethods.CheckForInvalidRegEx(TestCaseSearch, StringConstants.InvalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }

    [Test]
    public void WhenGivenListOfPaths_ThenGetFilenames()
    {
        var result = StringMethods.GetFileNames(TestCaseFilenames);
        List<string> expected = new List<string>()
        {
            "Invalid??File??Broken.nah",
            ":Invalid:Filename.txt"
        };

        CollectionAssert.AreEquivalent(expected, result);
    }

    [TestCaseSource(nameof(TestCaseFilenames))]
    public void WhenGivenInvalidFilenameList_ThenRemoveInvalidChars(string path)
    {
        var result = StringMethods.RemoveInvalidChars(path, StringConstants.InvalidFilenameChars);

        Assert.IsFalse(result.Any(StringConstants.InvalidFilenameChars.Contains));
    }
}