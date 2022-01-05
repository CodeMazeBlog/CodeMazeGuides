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
  <FirstName>aa</FirstName>
  <LastName>bb</LastName>
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
    <FirstName>aa</FirstName>
    <LastName>bb</LastName>
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
    <FirstName>cc</FirstName>
    <LastName>dd</LastName>
    <Birthday>1985-01-02T00:00:00</Birthday>
    <RoomNo>232</RoomNo>
    <HomeAddress>
      <Street>1 Market str.</Street>
      <Zip>11321</Zip>
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
            Patient patient = new Patient();
            patient.ID = 232323;
            patient.FirstName = "aa";
            patient.LastName = "bb";
            patient.Birthday = new DateTime(1990, 12, 30);
            patient.RoomNo = 310;
            patient.HomeAddress = new Address();
            patient.HomeAddress.Street = "12 Main str.";
            patient.HomeAddress.Zip = "23322";
            patient.HomeAddress.City = "Boston";
            patient.HomeAddress.Country = "USA";

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
            Patient[] arr = new Patient[2];
            arr[0] = new Patient();
            arr[0].ID = 232323;
            arr[0].FirstName = "aa";
            arr[0].LastName = "bb";
            arr[0].Birthday = new DateTime(1990, 12, 30);
            arr[0].RoomNo = 310;
            arr[0].HomeAddress = new Address();
            arr[0].HomeAddress.Street = "12 Main str.";
            arr[0].HomeAddress.Zip = "23322";
            arr[0].HomeAddress.City = "Boston";
            arr[0].HomeAddress.Country = "USA";

            arr[1] = new Patient();
            arr[1].ID = 454545;
            arr[1].FirstName = "cc";
            arr[1].LastName = "dd";
            arr[1].Birthday = new DateTime(1985, 1, 2);
            arr[1].RoomNo = 232;
            arr[1].HomeAddress = new Address();
            arr[1].HomeAddress.Street = "1 Market str.";
            arr[1].HomeAddress.Zip = "11321";
            arr[1].HomeAddress.City = "London";
            arr[1].HomeAddress.Country = "UK";

            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Patient[]));
                serializer.Serialize(writer, arr);
                Assert.AreEqual(xmlArr, Encoding.UTF8.GetString(stream.ToArray()));
            }
        }
    }
}