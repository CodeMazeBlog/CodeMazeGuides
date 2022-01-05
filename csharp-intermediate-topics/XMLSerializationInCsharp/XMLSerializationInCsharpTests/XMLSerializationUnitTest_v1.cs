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
  <FirstName>aa</FirstName>
  <LastName>bb</LastName>
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
            Patient patient = new Patient();
            patient.ID = 232323;
            patient.FirstName = "aa";
            patient.LastName = "bb";
            patient.Birthday = new DateTime(1990, 12, 30);
            patient.RoomNo = 310;

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