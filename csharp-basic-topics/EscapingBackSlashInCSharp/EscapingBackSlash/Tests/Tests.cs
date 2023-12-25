namespace Tests;

[TestClass]
public class Tests
{
    private const string path = "C:\\Users\\User\\Documents";

    [TestMethod]
    public void GivenDoubleBackslash_WhenCallingMethod_ThenReturnEscapedFilePath()
    {
        Assert.AreEqual(path, BackslashMethods.UsingDoubleBackslash());
    }

    [TestMethod]
    public void GivenVerbatimStringLiteral_WhenCallingMethod_ThenReturnFilePathWithVerbatimString()
    {
        Assert.AreEqual(path, BackslashMethods.UsingVerbatimStringLiteral());
    }

    [TestMethod]
    public void GivenUnicodeEscapeSequence_WhenCallingMethod_ThenReturnFilePathWithUnicodeEscape()
    {
        Assert.AreEqual(path, BackslashMethods.UsingUnicodeEscapeSequence());
    }

    [TestMethod]
    public void GivenStringFormatMethod_WhenCallingMethod_ThenReturnFormattedFilePath()
    {
        Assert.AreEqual(path, BackslashMethods.UsingStringFormat());
    }

    [TestMethod]
    public void GivenStringInterpolation_WhenCallingMethod_ThenReturnInterpolatedFilePath()
    {
        Assert.AreEqual(path, BackslashMethods.UsingStringInterpolation());
    }
}