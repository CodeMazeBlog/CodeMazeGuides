namespace Tests;
public class InvalidCharactersTests
{
    // known invalid paths
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
    // OS Agnostic known invalid char hashsets
    private static readonly HashSet<char> invalidPathChars = new HashSet<char>
    {
        '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a',
        '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011',
        '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018',
        '\u0019', '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f'
    };
    private static readonly HashSet<char> invalidFilenameChars = new HashSet<char>
    {
        '"', '<', '>', '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005',
        '\u0006', '\a', '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f',
        '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016',
        '\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d',
        '\u001e', '\u001f', ':', '*', '?', '\\', '/'
    };

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

        Assert.IsFalse(result.Any(invalidFilenameChars.Contains));
    }
}
