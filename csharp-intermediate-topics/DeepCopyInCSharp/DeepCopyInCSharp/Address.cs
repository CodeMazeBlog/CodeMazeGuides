using System.Diagnostics.CodeAnalysis;

namespace DeepCopyInCSharp
{
    [Serializable]
    public class Address : ICloneable
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }

        public Address() { }

        [SetsRequiredMembers]
        public Address(Address other)
        {
            Street = other.Street;
            City = other.City;
            State = other.State;
        }

        public object Clone()
        {
            return new Address
            {
                Street = Street,
                City = City,
                State = State
            };
        }
    }
}