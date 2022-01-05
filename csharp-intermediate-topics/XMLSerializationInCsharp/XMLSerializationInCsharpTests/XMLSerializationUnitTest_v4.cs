using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v4;

namespace XMLSerializationInCsharpTests
{
    public class XMLSerializationUnitTest_v4
    {
        string xml = @"﻿<?xml version=""1.0"" encoding=""utf-8""?>
<PatientInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" PatientID=""232323"">
  <FirstName>aa</FirstName>
  <LastName>bb</LastName>
  <RoomNumber>310</RoomNumber>
  <HomeAddress>
    <Street>12 Main str.</Street>
    <Zip>23322</Zip>
    <City>Boston</City>USA</HomeAddress>
  <TemperatureReadings>
    <TemperatureReading>
      <TimeTaken>2022-01-01T17:50:00</TimeTaken>
      <Temp>38.4</Temp>
    </TemperatureReading>
    <TemperatureReading>
      <TimeTaken>2022-01-01T22:00:00</TimeTaken>
      <Temp>39.1</Temp>
    </TemperatureReading>
    <TemperatureReading>
      <TimeTaken>2022-01-02T06:30:00</TimeTaken>
      <Temp>37.3</Temp>
    </TemperatureReading>
  </TemperatureReadings>
</PatientInfo>";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenSerializingWithAttributes_ThenCorrectXML()
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

            patient.Measurements = new List<Measurement>();
            patient.Measurements.Add(new Measurement() { TimeTaken = new DateTime(2022, 1, 1, 17, 50, 0), Temp = 38.4M });
            patient.Measurements.Add(new Measurement() { TimeTaken = new DateTime(2022, 1, 1, 22, 00, 0), Temp = 39.1M });
            patient.Measurements.Add(new Measurement() { TimeTaken = new DateTime(2022, 1, 2, 6, 30, 0), Temp = 37.3M });

            using (MemoryStream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Patient));
                serializer.Serialize(writer, patient);
                Assert.AreEqual(xml, Encoding.UTF8.GetString(stream.ToArray()));
            }
        }
    }
}