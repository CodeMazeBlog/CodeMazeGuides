using System;
using System.Collections.Generic;

namespace XMLSerializationInCsharp_v3
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int RoomNo { get; set; }
        public Address HomeAddress { get; set; }
        public List<Measurement> Measurements {get; set;}    
    }

    public class Address
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Measurement
    {
        public DateTime TimeTaken { get; set; }
        public decimal Temp { get; set; }
    }
}
