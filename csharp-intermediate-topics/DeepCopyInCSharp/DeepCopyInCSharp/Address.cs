namespace DeepCopyInCSharp
{
    [Serializable]
    public class Address : ICloneable
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }

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