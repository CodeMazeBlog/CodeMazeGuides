using System;

namespace XMLSerializationInCsharp_v2
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int RoomNo { get; set; }
        public Address HomeAddress { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
