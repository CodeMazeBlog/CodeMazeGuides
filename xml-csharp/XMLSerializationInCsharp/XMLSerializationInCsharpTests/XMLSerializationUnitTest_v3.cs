using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v3;

namespace XMLSerializationInCsharpTests
{
    public class XMLSerializationUnitTest_v3
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
  <Measurements>
    <Measurement>
      <TimeTaken>2022-01-01T17:50:00</TimeTaken>
      <Temp>38.4</Temp>
    </Measurement>
    <Measurement>
      <TimeTaken>2022-01-01T22:00:00</TimeTaken>
      <Temp>39.1</Temp>
    </Measurement>
    <Measurement>
      <TimeTaken>2022-01-02T06:30:00</TimeTaken>
      <Temp>37.3</Temp>
    </Measurement>
  </Measurements>
</Patient>";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenSerializingAClassWithAListOfObject_ThenCorrectXML()
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
                },
                Measurements = new List<Measurement>()
                {
                    new Measurement() { TimeTaken = new DateTime(2022, 1, 1, 17, 50, 0), Temp = 38.4M },
                    new Measurement() { TimeTaken = new DateTime(2022, 1, 1, 22, 00, 0), Temp = 39.1M },
                    new Measurement() { TimeTaken = new DateTime(2022, 1, 2, 6, 30, 0), Temp = 37.3M }
                }
            };

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(Patient));
                serializer.Serialize(writer, patient);
                Assert.AreEqual(xml, Encoding.UTF8.GetString(stream.ToArray()));
            }
        }
    }
}