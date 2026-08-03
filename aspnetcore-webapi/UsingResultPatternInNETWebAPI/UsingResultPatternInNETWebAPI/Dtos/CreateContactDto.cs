namespace UsingResultPatternInNETWebAPI.Dtos;

public sealed record CreateContactDto([EmailAddress] string Email);