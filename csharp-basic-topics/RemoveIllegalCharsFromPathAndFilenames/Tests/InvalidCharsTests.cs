public class InvalidCharactersTests
{
    // known invalid paths
    private static readonly IEnumerable<string> TestCaseSearch = new List<string> 
    {
        "C://User/Test/Stuff/Invalid>>>>?||?<<<<--Chars",
        "D://User/iLi?||?keToIncludeINVALIDChars/*/     z"
    };
    private static readonly IEnumerable<string> TestCaseFilenames = new List<string>
    {
        "A://ValidPath/SomeFolder/Invalid??File??Broken.nah",
        "I://ProgramFiles/SomeApplication/:Invalid:Filename.txt"
    };
    private static readonly HashSet<char> invalidPathChars = new HashSet<char>(Path.GetInvalidPathChars());
    private static readonly HashSet<char> invalidFilenameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidChars()
    {
        var result = StringMethods.CheckForInvalid(TestCaseSearch, invalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }
        
    [Test]
    public void WhenGivenlListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQ()
    {
        var result = StringMethods.CheckForInvalidLINQ(TestCaseSearch, invalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }
        
    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQHeaderFormat()
    {
        var result = StringMethods.CheckForInvalidLINQHeader(TestCaseSearch, invalidPathChars);
        CollectionAssert.AreEquivalent(TestCaseSearch, result);
    }

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingRegEx()
    {
        var result = StringMethods.CheckForInvalidRegEx(TestCaseSearch, invalidPathChars);
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
        var result = StringMethods.RemoveInvalidChars(path, invalidFilenameChars);

        if (result.Any(invalidFilenameChars.Contains)) { Assert.Fail(); }
        else { Assert.Pass(); }
    }
}