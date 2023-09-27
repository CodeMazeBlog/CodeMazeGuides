using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLSerializationInCsharp_v4
{
    [XmlRoot("PatientInfo")]
    public class Patient
    {
        [XmlAttribute ("PatientID")]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [XmlIgnore]
        public DateTime Birthday { get; set; }
        [XmlElement("RoomNumber")]
        public int RoomNo { get; set; }
        public Address HomeAddress { get; set; }
        [XmlArray("TemperatureReadings")]
        [XmlArrayItem("TemperatureReading")]
        public List<Measurement> Measurements {get; set;}    
    }

    public class Address
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        [XmlText]
        public string Country { get; set; }
    }

    public class Measurement
    {
        public DateTime TimeTaken { get; set; }
        public decimal Temp { get; set; }
    }
}
