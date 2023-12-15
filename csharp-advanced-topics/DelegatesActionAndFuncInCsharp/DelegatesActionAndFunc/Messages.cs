namespace DelegateFuncAppSample;

public record Messages
{
    public required int TypeMessage;
    public required string Recipient;
    public required string Message;
    public string? Email;
    public string? PhoneNumber;
}