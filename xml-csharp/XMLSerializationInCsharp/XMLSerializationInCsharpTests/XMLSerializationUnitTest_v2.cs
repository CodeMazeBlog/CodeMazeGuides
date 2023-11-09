using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v2;

namespace XMLSerializationInCsharpTests
{
    public class XMLSerializationUnitTest_v2
    {
        string xml = @"﻿<?xml version=""1.0"" encoding=""utf-8""?>
<Patient xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <ID>232323</ID>
  <FirstName>John</FirstName>
  <LastName>Doe</LastName>
  <Birthday>1990-12-30T00:00:00</Birthday>
  <RoomNo>310</RoomNo>
  <HomeAddress>
    <Street>12 Main str.</Street>
    <Zip>23322</Zip>
    <City>Boston</City>
    <Country>USA</Country>
  </HomeAddress>
</Patient>";

        string xmlArr = @"﻿<?xml version=""1.0"" encoding=""utf-8""?>
<ArrayOfPatient xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Patient>
    <ID>232323</ID>
    <FirstName>John</FirstName>
    <LastName>Doe</LastName>
    <Birthday>1990-12-30T00:00:00</Birthday>
    <RoomNo>310</RoomNo>
    <HomeAddress>
      <Street>12 Main str.</Street>
      <Zip>23322</Zip>
      <City>Boston</City>
      <Country>USA</Country>
    </HomeAddress>
  </Patient>
  <Patient>
    <ID>454545</ID>
    <FirstName>Jane</FirstName>
    <LastName>Doe</LastName>
    <Birthday>1985-01-02T00:00:00</Birthday>
    <RoomNo>232</RoomNo>
    <HomeAddress>
      <Street>8 Market str.</Street>
      <Zip>XS45E</Zip>
      <City>London</City>
      <Country>UK</Country>
    </HomeAddress>
  </Patient>
</ArrayOfPatient>";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenSerializingAClassWithComplexObject_ThenCorrectXML()
        {
            var patient = new Patient()
            {
                ID = 232323,
                FirstName = "John",
                LastName = "Doe",
                Birthday = new DateTime(1990, 12, 30),
                RoomNo = 310,
                HomeAddress = new Address()
                {
                    Street = "12 Main str.",
                    Zip = "23322",
                    City = "Boston",
                    Country = "USA",
                }
            };

            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Patient));
                serializer.Serialize(writer, patient);
                Assert.AreEqual(xml, Encoding.UTF8.GetString(stream.ToArray()));
            }
        }

        [Test]
        public void WhenSerializingAnArrayOfObjects_ThenCorrectXML()
        {
            var arr = new Patient[]
            {
                new Patient()
                {
                    ID = 232323,
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = new DateTime(1990, 12, 30),
                    RoomNo = 310,
                    HomeAddress = new Address()
                    {
                        Street = "12 Main str.",
                        Zip = "23322",
                        City = "Boston",
                        Country = "USA",
                    }
                },
                new Patient()
                {
                    ID = 454545,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Birthday = new DateTime(1985, 1, 2),
                    RoomNo = 232,
                    HomeAddress = new Address()
                    {
                        Street = "8 Market str.",
                        Zip = "XS45E",
                        City = "London",
                        Country = "UK",
                    }
                }
            };

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(Patient[]));
                serializer.Serialize(writer, arr);
                Assert.AreEqual(xmlArr, Encoding.UTF8.GetString(stream.ToArray()));
            }
        }
    }
}