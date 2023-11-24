using System;
using System.Xml.Serialization;

namespace XMLSerializationInCsharp_v5
{
    [XmlInclude(typeof(Doctor))]
    [XmlInclude(typeof(Patient))]
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class Doctor: Person
    { 
        public string Specialization { get; set; }
    }

    public class Patient: Person
    {
        public int RoomNo { get; set; }
    }
}
