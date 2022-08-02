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
        Member[] members = new Member[]
        {
            new Student()
            {
                Name = "John Doe",
                BirthDate = new DateTime(2000, 2, 4),
                RegistrationYear = 2019,
                Courses = new List<string>()
                {
                    "Algorithms",
                    "Databases",
                }
            },
            new Professor()
            {
                Name = "Jane Doe",
                BirthDate = new DateTime(1978, 6, 6),
                Rank = "Full Professor",
                IsTenured = true
            },
            new Student()
            {
                Name = "Jason Doe",
                BirthDate = new DateTime(2002, 7, 8),
                RegistrationYear = 2020,
                Courses = new List<string>()
                {
                    "Databases"
                }
            }
        };

        string json = @"[
  {
	""MemberType"" : ""Student"",
    ""Name"": ""John Doe"",
    ""BirthDate"": ""2000-02-04T00:00:00"",
    ""RegistrationYear"" : 2019,
    ""Courses"": [
        ""Algorithms"",
        ""Databases""
    ]
  },
  {
    ""MemberType"" : ""Professor"",
    ""Name"": ""Jane Doe"",
    ""BirthDate"": ""1978-06-06T00:00:00"",
    ""Rank"" : ""Full Professor"",
    ""IsTenured"" : true
  },
  {
    ""MemberType"" : ""Student"",
    ""Name"": ""Jason Doe"",
    ""BirthDate"": ""2002-07-07T00:00:00"",
    ""RegistrationYear"" : 2020,
    ""Courses"": [
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
            var membersJson = JsonSerializer.Serialize<Member[]>(members);
            Assert.IsFalse(membersJson.Contains("Courses"));
            Assert.IsFalse(membersJson.Contains("RegistrationYear"));
            Assert.IsFalse(membersJson.Contains("Rank"));
            Assert.IsFalse(membersJson.Contains("IsTenured"));
        }

        [Test]
        public void WhenUsingSimpleSerializationWithObject_ThenDerivedClassPropertiesArePresent()
        {
            var membersJson = JsonSerializer.Serialize<object[]>(members);
            Assert.IsTrue(membersJson.Contains("Courses"));
            Assert.IsTrue(membersJson.Contains("RegistrationYear"));
            Assert.IsTrue(membersJson.Contains("Rank"));
            Assert.IsTrue(membersJson.Contains("IsTenured"));
        }

        [Test]
        public void WhenUsingCustomConverterSerialization_ThenDerivedClassPropertiesArePresent()
        {
            var membersJson = JsonSerializer.Serialize<Member[]>(members, options);
            Assert.IsTrue(membersJson.Contains("Courses"));
            Assert.IsTrue(membersJson.Contains("RegistrationYear"));
            Assert.IsTrue(membersJson.Contains("Rank"));
            Assert.IsTrue(membersJson.Contains("IsTenured"));
        }

        [Test]
        public void WhenUsingCustomConverterDeserialization_ThenDerivedClassPropertiesArePresent()
        {
            var deserializedList = JsonSerializer.Deserialize<List<Member>>(json, options);
            var john = deserializedList?.FirstOrDefault(p => p.Name == "John Doe");
            Assert.IsNotNull(john);
            Assert.AreEqual(((Student?)john)?.RegistrationYear, 2019);
            Assert.AreEqual(((Student?)john)?.Courses.Count, 2);

            var jane = deserializedList?.FirstOrDefault(p => p.Name == "Jane Doe");
            Assert.IsNotNull(jane);
            Assert.AreEqual(((Professor?)jane)?.Rank, "Full Professor");
            Assert.AreEqual(((Professor?)jane)?.IsTenured, true);
        }
    }
}