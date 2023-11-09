using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v5;

namespace XMLSerializationInCsharpTests
{
    public class XMLSerializationUnitTest_v5
    {
        string xml = @"﻿<?xml version=""1.0"" encoding=""utf-8""?>
<ArrayOfPerson xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Person xsi:type=""Doctor"">
    <ID>777</ID>
    <FirstName>Jane</FirstName>
    <LastName>Doe</LastName>
    <Birthday>1975-03-05T00:00:00</Birthday>
    <Specialization>Cardiologist</Specialization>
  </Person>
  <Person xsi:type=""Patient"">
    <ID>888</ID>
    <FirstName>John</FirstName>
    <LastName>Doe</LastName>
    <Birthday>1980-03-21T00:00:00</Birthday>
    <RoomNo>301</RoomNo>
  </Person>
</ArrayOfPerson>";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenSerializingAListOfDerivedObjects_ThenCorrectXML()
        {
            var people = new List<Person>()
            {
                new Doctor()
                {
                    ID = 777,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Birthday = new DateTime(1975, 3, 5),
                    Specialization = "Cardiologist"
                },
                new Patient()
                {
                    ID = 888,
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = new DateTime(1980, 3, 21),
                    RoomNo = 301
                }
            };

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(List<Person>));
                serializer.Serialize(writer, people);
                Assert.AreEqual(xml, Encoding.UTF8.GetString(stream.ToArray()));
            }
        } 
    }
}