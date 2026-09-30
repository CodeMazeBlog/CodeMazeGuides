using FirstLetterToUpper;

namespace FirstLetterToUpperTests;

[TestClass]
public class FirstLetterToUpperUnitTests
{
    private readonly FirstLetterToUpperMethods _upperCase = new();

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingSubStringTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharSubstring(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingCharToUpperTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharToUpper(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingCharArrayTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharToCharArray(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingAsSpanTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharToUpperAsSpan(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingStringCreateTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharToUpperStringCreate(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingRegexTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharToUpperRegex(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenANonAsciiLowerCaseString_WhenUsingRegexTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "élan vital";
        var returnedString = _upperCase.FirstCharToUpperRegex(testString);

        Assert.AreEqual("Élan vital", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingLinqTechnique_VerifyFirstCharIsUpper()
    {
        var testString = "this is a test string";
        var returnedString = _upperCase.FirstCharToUpperLinq(testString);

        Assert.AreEqual("This is a test string", returnedString);
    }

    [TestMethod]
    public void GivenALowerCaseString_WhenUsingUnsafeCodeTechnique_VerifyFirstCharIsUpper()
    {
        var testString = new string("unsafe demo input".ToCharArray());
        var returnedString = _upperCase.FirstCharToUpperUnsafeCode(testString);

        Assert.AreEqual("Unsafe demo input", returnedString);
    }

    [TestMethod]
    public void GivenTwoVariablesHoldingTheSameString_WhenUsingUnsafeCode_ThenBothStringsChange()
    {
        var first = new string("mutation demo".ToCharArray());
        var second = first;

        _upperCase.FirstCharToUpperUnsafeCode(first);

        Assert.AreEqual("Mutation demo", second);
    }
}
