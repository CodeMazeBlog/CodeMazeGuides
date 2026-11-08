using ValidateEmailAddress;

namespace Tests;

// One row per input: what each approach answers on .NET 10.
// Columns: MailAddress (constructor and TryCreate agree), EmailAddressAttribute
// (FluentValidation's default mode agrees), our regex, FluentValidation Net4xRegex.
public class ValidatorComparisonTests
{
    private readonly EmailValidator _emailValidator = new();

    [Theory]
    [InlineData("code@maze.com", true, true, true, true)]
    [InlineData("code@maze", true, true, true, false)]
    [InlineData("code@.maze.com", false, true, false, false)]
    [InlineData("co,de@maze.com", false, true, false, false)]
    [InlineData("code..maze@maze.com", false, true, false, false)]
    [InlineData("code maze@maze.com", false, true, false, false)]
    [InlineData("Code Maze <code@maze.com>", false, true, false, false)]
    [InlineData("\"code maze\"@maze.com", true, true, false, true)]
    [InlineData("ćode@maze.com", true, true, false, true)]
    public void GivenAnEmail_WhenComparingApproaches_ThenEachReturnsTheDocumentedResult(
        string email, bool mailAddress, bool attribute, bool regex, bool net4xRegex)
    {
        Assert.Equal(mailAddress, _emailValidator.ValidateUsingMailAddress(email));
        Assert.Equal(mailAddress, _emailValidator.ValidateUsingMailAddressTryCreate(email));
        Assert.Equal(attribute, _emailValidator.ValidateUsingEmailAddressAttribute(email));
        Assert.Equal(attribute, _emailValidator.ValidateUsingFluentValidator(email));
        Assert.Equal(regex, _emailValidator.ValidateUsingRegex(email));
        Assert.Equal(regex, _emailValidator.ValidateUsingGeneratedRegex(email));
        Assert.Equal(net4xRegex, _emailValidator.ValidateUsingFluentRegexValidator(email));
    }
}
