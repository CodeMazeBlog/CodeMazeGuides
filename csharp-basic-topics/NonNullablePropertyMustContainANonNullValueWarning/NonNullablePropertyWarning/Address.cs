namespace NonNullablePropertyWarning
{
    public class Address
    {
        public string FirstName { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public string MiddleName { get; set; }

        // A field-keyword property reports CS9264, which this CS8618 pragma does not suppress
        public string Region { get; set => field = value; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

#nullable disable
        public string LastName { get; set; }
#nullable restore

        public string City { get; set; } = "Default City";

        public string? Country { get; set; }

        public string PostalCode { get; set; } = null!;

        public required string Area { get; set; }

        public string Town
        {
            get => field ?? string.Empty;
            set => field = value;
        }
    }
}