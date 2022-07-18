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
                HomeAddress = new Address()
                {
                    Street = "3 Main str.",
                    ZipCode = "22323",
                    City = "Boston",
                    Country = "USA"
                },
                RegistrationYear = 2019,
                CoursesTaken = new List<Course>()
                {
                    new Course()
                    {
                        Name = "Algorithms",
                        Semester = 2
                    },
                    new Course()
                    {
                        Name = "Databases",
                        Semester = 1
                    }
                }
            },
            new Professor()
            {
                FirstName = "Jane",
                LastName =  "Doe",
                BirthDate = new DateTime(1978, 6, 6),
                HomeAddress = new Address()
                {
                    Street = "1 Market str.",
                    ZipCode = "HHFW33",
                    City = "London",
                    Country = "UK"
                },
                OfficeNumber = "222A",
                CoursesOffered = new List<Course>()
                {
                    new Course()
                    {
                        Name = "Algorithms",
                        Semester = 2
                    }
                }
            },
            new Student()
            {
                FirstName = "Jason",
                LastName =  "Doe",
                BirthDate = new DateTime(2002, 7, 8),
                HomeAddress = new Address()
                {
                    Street = "5 First str.",
                    ZipCode = "43422",
                    City = "New York",
                    Country = "USA"
                },
                RegistrationYear = 2020,
                CoursesTaken = new List<Course>()
                {
                    new Course()
                    {
                        Name = "Databases",
                        Semester = 1
                    }
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
    ""HomeAddress"": null,
    ""CoursesTaken"": [
      {
        ""Name"": ""Algorithms"",
        ""Semester"": 2
      },
      {
        ""Name"": ""Databases"",
        ""Semester"": 1
      }
    ]
  },
  {
    ""PersonType"" : ""Professor"",
    ""FirstName"": ""Jane"",
    ""LastName"": ""Doe"",
    ""BirthDate"": ""1978-06-06T00:00:00"",
    ""OfficeNumber"" : ""222A"",
    ""HomeAddress"": null,
    ""CoursesOffered"": [
      {
        ""Name"": ""Algorithms"",
        ""Semester"": 2
      }
    ]
  },
  {
    ""PersonType"" : ""Student"",
    ""FirstName"": ""Jason"",
    ""LastName"": ""Doe"",
    ""BirthDate"": ""2002-07-07T00:00:00"",
    ""RegistrationYear"" : 2020,
    ""HomeAddress"": null,
    ""CoursesTaken"": [
      {
        ""Name"": ""Databases"",
        ""Semester"": 1
      }
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