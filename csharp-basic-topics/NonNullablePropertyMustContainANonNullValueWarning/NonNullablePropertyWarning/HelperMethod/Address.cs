using System.Diagnostics.CodeAnalysis;

namespace NonNullablePropertyWarning.HelperMethod
{
    public class Address
    {
        public string City { get; set; }

        public Address() => SetCity();

        public Address(string city) => SetCity(city);

        [MemberNotNull(nameof(City))]
        private void SetCity(string? city = default) => City = city ?? "Default City";
    }
}
