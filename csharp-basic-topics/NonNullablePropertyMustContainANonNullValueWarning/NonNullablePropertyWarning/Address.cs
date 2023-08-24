namespace NonNullablePropertyWarning
{
    public class Address
    {
        public string FirstName { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string MiddleName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

#nullable disable
        public string LastName { get; set; }
#nullable restore

        public string City { get; set; } = "Default City";

        public string? Country { get; set; }

        public string PostalCode { get; set; } = null!;

        public required string Area { get; set; }
    }
}