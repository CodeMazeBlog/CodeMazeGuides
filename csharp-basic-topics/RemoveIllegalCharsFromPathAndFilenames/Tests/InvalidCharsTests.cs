public class Tests
{
    // known invalid paths
    static readonly List<string> TestCaseSearch = new List<string> 
    {
        "C://User/Test/Stuff/Invalid>>>>\r<<<<--Chars",
        "D://User/iLi\0keToIncludeINVALIDChars/*/     z"
    };
    static readonly List<string> TestCaseFilenames = new List<string>
    {
        "A://ValidPath/SomeFolder/Invalid??File??Broken.nah",
        "I://ProgramFiles/SomeApplication/:Invalid:Filename.txt"
    };
    HashSet<char> invalidPathChars = new HashSet<char>(Path.GetInvalidPathChars());
    HashSet<char> invalidFilenameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidChars()
    {
        var result = StringMethods.CheckForInvalid(TestCaseSearch, invalidPathChars);
        Assert.That(TestCaseSearch, Is.EqualTo(result));
    }
        
    [Test]
    public void WhenGivenlListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQ()
    {
        var result = StringMethods.CheckForInvalidLINQ(TestCaseSearch, invalidPathChars);
        Assert.That(TestCaseSearch, Is.EqualTo(result));
    }
        
    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingLINQHeaderFormat()
    {
        var result = StringMethods.CheckForInvalidLINQHeader(TestCaseSearch, invalidPathChars);
        Assert.That(TestCaseSearch, Is.EqualTo(result));
    }

    [Test]
    public void WhenGivenListOfStrings_ThenFindStringsWithInvalidCharsUsingRegEx()
    {
        var result = StringMethods.CheckForInvalidRegEx(TestCaseSearch, invalidPathChars);
        Assert.That(TestCaseSearch, Is.EqualTo(result));
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

        Assert.That(expected, Is.EqualTo(result));
    }
        
    [Test]
    public void WhenGivenInvalidFilenameList_ThenRemoveInvalidChars()
    {
        foreach (string path in TestCaseFilenames)
        {
            var result = StringMethods.RemoveInvalidChars(path, invalidFilenameChars);

            if (result.Any(invalidFilenameChars.Contains))
            {
                Assert.Fail();                    
            }
        }

        Assert.Pass();
    }
}