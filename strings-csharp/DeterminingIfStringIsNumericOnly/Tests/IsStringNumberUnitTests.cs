using DeterminingIfStringIsNumericOnly;

namespace Tests;

public class IsStringNumberUnitTests
{
    private const string IntegerString = "1234567890";
    private const string AlphanumericString = "1234567890abc";
    private static readonly IsStringNumber IsStringNumber = new();
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithNewRegex_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithNewRegex(input);
        
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithNewRegex_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithNewRegex(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithCompiledRegex_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithCompiledRegex(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithCompiledRegex_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithCompiledRegex(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithTryParse_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithTryParse(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase("12345678901234567890", false)]
    public void GivenIsNumericWithTryParse_WhenInputIsIntegerOnlyButGreaterThanIntMaxValue_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithTryParse(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithTryParse_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithTryParse(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithForeachCharIsDigit_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithForeachCharIsDigit(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithForeachCharIsDigit_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithForeachCharIsDigit(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithForeachCharIsBetween09_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithForeachCharIsBetween09(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithForeachCharIsBetween09_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithForeachCharIsBetween09(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithLinqAllCharIsBetween09_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithLinqAllCharIsBetween09(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithLinqAllCharIsBetween09_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithLinqAllCharIsBetween09(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(IntegerString, true)]
    public void GivenIsNumericWithLinqAllCharIsDigit_WhenInputIsIntegerOnly_ThenReturnsTrue(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithLinqAllCharIsDigit(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase(AlphanumericString, false)]
    public void GivenIsNumericWithLinqAllCharIsDigit_WhenInputContainsOtherCharacters_ThenReturnsFalse(string input, bool expectedResult)
    {
        var result = IsStringNumber.IsNumericWithLinqAllCharIsDigit(input);
        
        Assert.That(result, Is.False);
    }
}