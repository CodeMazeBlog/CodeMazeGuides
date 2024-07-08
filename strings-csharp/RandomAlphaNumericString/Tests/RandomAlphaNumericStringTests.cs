using RandomAlphaNumericString;

[TestClass]
public class RandomAlphaNumericStringTests
{
    private readonly int expectedLength = 16;


    [TestMethod]
    public void GivenRandomNumberGenGetStringMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.RandomNumberGenGetStringMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenCryptographicUniqueMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.CryptographicUniqueMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenGuidMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.GuidMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenLinqMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.LinqMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenStringCreateMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.StringCreateMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenStringCreateSecureMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.StringCreateSecureMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenStringBuilderMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.StringBuilderMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenSpanMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.SpanMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenSpanSecureMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.SpanSecureMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenPreSpanSecureMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.PreSpanSecureMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }

    [TestMethod]
    public void GivenOldSpanSecureMethod_WhenCalled_ThenReturnsStringOfExpectedLength()
    {
        var result = Methods.OldSpanSecureMethod(expectedLength);
        Assert.AreEqual(expectedLength, result.Length);
    }
}
