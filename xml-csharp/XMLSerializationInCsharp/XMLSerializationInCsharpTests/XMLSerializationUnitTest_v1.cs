using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v1;

namespace XMLSerializationInCsharpTests
{
    public class XMLSerializationUnitTest_v1
    {
        string xml = @"﻿<?xml version=""1.0"" encoding=""utf-8""?>
<Patient xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <ID>232323</ID>
  <FirstName>John</FirstName>
  <LastName>Doe</LastName>
  <Birthday>1990-12-30T00:00:00</Birthday>
  <RoomNo>310</RoomNo>
</Patient>";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenSerializingASimpleClass_ThenCorrectXML()
        {
            var patient = new Patient()
            {
                ID = 232323,
                FirstName = "John",
                LastName = "Doe",
                Birthday = new DateTime(1990, 12, 30),
                RoomNo = 310
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