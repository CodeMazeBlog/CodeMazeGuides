namespace DeepCopyInCSharp
{
    [Serializable]
    public class Address : ICloneable
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

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