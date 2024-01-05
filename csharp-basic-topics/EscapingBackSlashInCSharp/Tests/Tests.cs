namespace Tests;

[TestClass]
public class Tests
{
    private const string ExpectedPath = @"C:\Users\User\Documents";
    
    private static readonly char PathSeparator = Path.DirectorySeparatorChar;
    private static readonly string PathUsingDirSeparator =
        $"C:{PathSeparator}Users{PathSeparator}User{PathSeparator}Documents";

    [TestMethod]
    public void GivenDoubleBackslash_WhenCallingMethod_ThenReturnEscapedFilePath()
    {
        Assert.AreEqual(ExpectedPath, BackslashMethods.UsingDoubleBackslash());
    }

    [TestMethod]
    public void GivenVerbatimStringLiteral_WhenCallingMethod_ThenReturnFilePathWithVerbatimString()
    {
        Assert.AreEqual(ExpectedPath, BackslashMethods.UsingVerbatimStringLiteral());
    }

    [TestMethod]
    public void GivenUnicodeEscapeSequence_WhenCallingMethod_ThenReturnFilePathWithUnicodeEscape()
    {
        Assert.AreEqual(ExpectedPath, BackslashMethods.UsingUnicodeEscapeSequence());
    }

    [TestMethod]
    public void GivenStringFormatMethod_WhenCallingMethod_ThenReturnFormattedFilePath()
    {   
        Assert.AreEqual(PathUsingDirSeparator, BackslashMethods.UsingStringFormat());
    }

    [TestMethod]
    public void GivenStringInterpolation_WhenCallingMethod_ThenReturnInterpolatedFilePath()
    {
        Assert.AreEqual(PathUsingDirSeparator, BackslashMethods.UsingStringFormat());
    }
}