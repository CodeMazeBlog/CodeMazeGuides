using JsonPolymorphicSerialization;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace JsonPolymorphicSerializationUnitTests
{
    public class Tests
    {
        Person[] list = new Person[]
        {
            new Student()
            {
                FirstName = "John",
                LastName =  "Doe",
                BirthDate = new DateTime(2000, 2, 4),
                HomeAddress = "3 Main str., 22323 Boston, USA",
                RegistrationYear = 2019,
                CoursesTaken = new List<string>()
                {
                    "Algorithms",
                    "Databases",
                }
            },
            new Professor()
            {
                FirstName = "Jane",
                LastName =  "Doe",
                BirthDate = new DateTime(1978, 6, 6),
                HomeAddress = "1 Market str., HHFW33 London, UK",
                OfficeNumber = "222A",
                CoursesOffered = new List<string>()
                {
                    "Algorithms"
                }
            },
            new Student()
            {
                FirstName = "Jason",
                LastName =  "Doe",
                BirthDate = new DateTime(2002, 7, 8),
                HomeAddress = "5 First str., 43422 New York, USA",
                RegistrationYear = 2020,
                CoursesTaken = new List<string>()
                {
                    "Databases",
                }
            }
        };

        string json = @"[
  {
	""PersonType"" : ""Student"",
    ""FirstName"": ""John"",
    ""LastName"": ""Doe"",
    ""BirthDate"": ""2000-02-04T00:00:00"",
    ""RegistrationYear"" : 2019,
    ""HomeAddress"": ""3 Main str., 22323 Boston, USA"",
    ""CoursesTaken"": [
        ""Algorithms"",
        ""Databases""
    ]
  },
  {
    ""PersonType"" : ""Professor"",
    ""FirstName"": ""Jane"",
    ""LastName"": ""Doe"",
    ""BirthDate"": ""1978-06-06T00:00:00"",
    ""OfficeNumber"" : ""222A"",
    ""HomeAddress"": ""1 Market str., HHFW33 London, UK"",
    ""CoursesOffered"": [
        ""Algorithms""
     ]
  },
  {
    ""PersonType"" : ""Student"",
    ""FirstName"": ""Jason"",
    ""LastName"": ""Doe"",
    ""BirthDate"": ""2002-07-07T00:00:00"",
    ""RegistrationYear"" : 2020,
    ""HomeAddress"": ""5 First str., 43422 New York, USA"",
    ""CoursesTaken"": [
        ""Databases""
    ]
  }
]";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Converters = { new UniversityJsonConverter() },
            WriteIndented = true
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenUsingSimpleSerialization_ThenDerivedClassPropertiesAreAbsent()
        {
            var personsJson = JsonSerializer.Serialize<Person[]>(list);
            Assert.IsFalse(personsJson.Contains("CoursesTaken"));
            Assert.IsFalse(personsJson.Contains("CoursesOffered"));
            Assert.IsFalse(personsJson.Contains("RegistrationYear"));
            Assert.IsFalse(personsJson.Contains("OfficeNumber"));
        }

        [Test]
        public void WhenUsingSimpleSerializationWithObject_ThenDerivedClassPropertiesArePresent()
        {
            var personsJson = JsonSerializer.Serialize<object[]>(list);
            Assert.IsTrue(personsJson.Contains("CoursesTaken"));
            Assert.IsTrue(personsJson.Contains("CoursesOffered"));
            Assert.IsTrue(personsJson.Contains("RegistrationYear"));
            Assert.IsTrue(personsJson.Contains("OfficeNumber"));
        }

        [Test]
        public void WhenUsingCustomConverterSerialization_ThenDerivedClassPropertiesArePresent()
        {
            var personsJson = JsonSerializer.Serialize<Person[]>(list, options);
            Assert.IsTrue(personsJson.Contains("CoursesTaken"));
            Assert.IsTrue(personsJson.Contains("CoursesOffered"));
            Assert.IsTrue(personsJson.Contains("RegistrationYear"));
            Assert.IsTrue(personsJson.Contains("OfficeNumber"));
        }

        [Test]
        public void WhenUsingCustomConverterDeserialization_ThenDerivedClassPropertiesArePresent()
        {
            var deserializedList = JsonSerializer.Deserialize<List<Person>>(json, options);
            var john = deserializedList?.FirstOrDefault(p => p.FirstName == "John");
            Assert.IsNotNull(john);
            Assert.AreEqual(((Student?)john)?.RegistrationYear, 2019);
            Assert.AreEqual(((Student?)john)?.CoursesTaken.Count, 2);

            var jane = deserializedList?.FirstOrDefault(p => p.FirstName == "Jane");
            Assert.IsNotNull(jane);
            Assert.AreEqual(((Professor?)jane)?.OfficeNumber, "222A");
            Assert.AreEqual(((Professor?)jane)?.CoursesOffered.Count, 1);
        }
    }
}