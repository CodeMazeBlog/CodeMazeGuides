namespace Tests;

public class ExampleTestCases
{
    [Theory]
    [InlineData("hello")]
    [InlineData("HELLO")]
    [InlineData("Olá")]
    public void GivenAText_WhenUsedLinqIsOnlyLettersCheck_ThenShouldReturnTrue(string text)
    {
        var isOnlyLetters = LinqStringChecker.IsOnlyLetters(text);

        Assert.True(isOnlyLetters);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("HELLO")]
    public void GivenAText_WhenUsedLinqIsOnlyAsciiLettersCheck_ThenShouldReturnTrue(string text) 
    {
        var isOnlyLetters = LinqStringChecker.IsOnlyLetters(text);

        Assert.True(isOnlyLetters);
    }

    [Theory]
    [InlineData("Olá")]
    [InlineData("2611")]
    public void GivenAText_WhenUsedLinqIsOnlyAsciiLettersCheck_ThenShouldReturnFalse(string text)
    {
        var isOnlyLetters = LinqStringChecker.IsOnlyAsciiLetters(text);

        Assert.False(isOnlyLetters);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("HELLO")]
    [InlineData("Olá")]
    public void GivenAText_WhenUsedRegexIsOnlyLettersCheck_ThenShouldReturnTrue(string text)
    {
        var isOnlyLetters = RegexStringChecker.IsOnlyLetters(text);

        Assert.True(isOnlyLetters);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("HELLO")]
    public void GivenAText_WhenUsedRegexIsOnlyAsciiLettersCheck_ThenShouldReturnTrue(string text)
    {
        var isOnlyLetters = RegexStringChecker.IsOnlyLetters(text);

        Assert.True(isOnlyLetters);
    }

    [Theory]
    [InlineData("OLÁ")]
    [InlineData("2611")]
    public void GivenAText_WhenUsedRegexIsOnlyAsciiLettersCheck_ThenShouldReturnFalse(string text)
    {
        var isOnlyLetters = RegexStringChecker.IsOnlyAciiLetters(text);

        Assert.False(isOnlyLetters);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("HELLO")]
    public void GivenAText_WhenUsedNativePatterMachingIsOnlyAsciiLettersCheck_ThenShouldReturnTrue(string text)
    {
        var isOnlyLetters = NativeStringChecker.IsOnlyAsciiLettersByPatternMatching(text);

        Assert.True(isOnlyLetters);
    }

    [Theory]
    [InlineData("OLÁ")]
    [InlineData("2611")]
    public void GivenAText_WhenUsedNativePatterMachingIsOnlyAsciiLettersCheck_ThenShouldReturnFalse(string text)
    {
        var isOnlyLetters = NativeStringChecker.IsOnlyAsciiLettersByPatternMatching(text);

        Assert.False(isOnlyLetters);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("HELLO")]
    public void GivenAText_WhenUsedSwitchCaseNativeIsOnlyAsciiLettersCheck_ThenShouldReturnTrue(string text)
    {
        var isOnlyLetters = NativeStringChecker.IsOnlyAsciiLettersBySwitchCase(text);

        Assert.True(isOnlyLetters);
    }

    [Theory]
    [InlineData("OLÁ")]
    [InlineData("2611")]
    public void GivenAText_WhenUsedSwitchCaseNativeIsOnlyAsciiLettersCheck_ThenShouldReturnFalse(string text)
    {
        var isOnlyLetters = NativeStringChecker.IsOnlyAsciiLettersBySwitchCase(text);

        Assert.False(isOnlyLetters);
    }

}