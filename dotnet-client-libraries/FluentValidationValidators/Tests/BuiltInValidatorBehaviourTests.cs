using FluentValidation;

namespace Tests;

/// <summary>
/// These tests pin the two library behaviours the article states as facts, so that a package
/// bump that changes either of them fails CI instead of silently making the article wrong.
/// </summary>
[TestClass]
public class BuiltInValidatorBehaviourTests
{
    private class EmailHolder
    {
        public string Email { get; set; }
    }

    private class EmailHolderValidator : AbstractValidator<EmailHolder>
    {
        public EmailHolderValidator() => RuleFor(model => model.Email).EmailAddress();
    }

    private static bool IsAcceptedAsEmail(string value)
        => new EmailHolderValidator().Validate(new EmailHolder { Email = value }).IsValid;

    [TestMethod]
    [DataRow("joebloggs@someemaildomain.com")]
    [DataRow("a@b")]
    [DataRow("has space@x.com")]
    public void EmailAddressValidator_AcceptsAnythingWithASingleAtSign(string value)
    {
        Assert.IsTrue(IsAcceptedAsEmail(value));
    }

    [TestMethod]
    [DataRow("not-an-email")]
    [DataRow("plain")]
    [DataRow("a@b@c")]
    public void EmailAddressValidator_RejectsValuesWithoutExactlyOneAtSign(string value)
    {
        Assert.IsFalse(IsAcceptedAsEmail(value));
    }

    [TestMethod]
    public void CascadeMode_DeclaresOnlyContinueAndStop()
    {
        CollectionAssert.AreEquivalent(
            new[] { "Continue", "Stop" },
            Enum.GetNames<CascadeMode>());
    }
}
