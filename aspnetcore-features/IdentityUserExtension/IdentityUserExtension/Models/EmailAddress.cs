namespace IdentityUserExtension.Models;

public sealed class EmailAddress
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public bool UsedForLogin { get; set; }
}