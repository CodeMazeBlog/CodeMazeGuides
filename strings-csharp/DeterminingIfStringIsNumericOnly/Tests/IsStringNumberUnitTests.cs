using DeterminingIfStringIsNumericOnly;

namespace Tests;

public class IsStringNumberUnitTests
{
    [Test]
    public void GivenIsNumericWithNewRegex_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithNewRegex(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithNewRegex_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithNewRegex(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithCompiledRegex_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithCompiledRegex(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithCompiledRegex_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithCompiledRegex(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithTryParse_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithTryParse(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithTryParse_WhenInputIsIntegerOnlyButGreaterThanIntMaxValue_ThenReturnsFalse()
    {
        const string input = "12345678901234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithTryParse(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithTryParse_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithTryParse(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithForeachCharIsDigit_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithForeachCharIsDigit(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithForeachCharIsDigit_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithForeachCharIsDigit(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithForeachCharIsBetween09_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithForeachCharIsBetween09(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithForeachCharIsBetween09_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithForeachCharIsBetween09(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithLinqAllCharIsBetween09_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithLinqAllCharIsBetween09(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithLinqAllCharIsBetween09_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithLinqAllCharIsBetween09(input);
        
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void GivenIsNumericWithLinqAllCharIsDigit_WhenInputIsIntegerOnly_ThenReturnsTrue()
    {
        const string input = "1234567890";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithLinqAllCharIsDigit(input);
        
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void GivenIsNumericWithLinqAllCharIsDigit_WhenInputContainsOtherCharacters_ThenReturnsFalse()
    {
        const string input = "1234567890abc";
        var isStringNumber = new IsStringNumber();
        
        var result = isStringNumber.IsNumericWithLinqAllCharIsDigit(input);
        
        Assert.That(result, Is.False);
    }
}