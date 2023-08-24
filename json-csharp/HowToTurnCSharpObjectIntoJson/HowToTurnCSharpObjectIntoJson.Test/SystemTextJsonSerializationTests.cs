using HowToTurnCSharpObjectIntoJson.Converters;
using HowToTurnCSharpObjectIntoJson.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Test
{
    [TestClass]
    public class SystemTextJsonSerializationTests
    {
        [TestMethod]
        public void WhenSerializingObject_ThenCorrectJsonString()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            // act
            var jsonString = JsonSerializer.Serialize(obj);

            // assert
            Assert.AreEqual("{\"Name\":\"Red Apples\",\"Stock\":100,\"DateAcquired\":\"2017-08-24T00:00:00\"}", jsonString);
        }

        [TestMethod]
        public void WhenWriteIndentedTrue_ThenPrintIndented()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            // act
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Red Apples\",{Environment.NewLine}  \"Stock\": 100,{Environment.NewLine}  \"DateAcquired\": \"2017-08-24T00:00:00\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenPropertyNamingPolicyCamelCase_ThenJsonHasCamelCaseProperties()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            // act
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var jsonString = JsonSerializer.Serialize(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"name\": \"Red Apples\",{Environment.NewLine}  \"stock\": 100,{Environment.NewLine}  \"dateAcquired\": \"2017-08-24T00:00:00\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenIgnoringNullValues_ThenNullPropertiesNotSerialized()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = null,
                DateAcquired = null
            };

            // act
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var jsonString = JsonSerializer.Serialize(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Red Apples\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenJsonIgnoreAttribute_ThenPropertyNotSerialized()
        {
            // arrange
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            // act
            var obj = new Customer
            {
                Name = "Pumpkins And Roses",
                Address = "158 Barfield Rd",
                FinancialRating = 4.5M
            };

            var jsonString = JsonSerializer.Serialize(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Pumpkins And Roses\",{Environment.NewLine}  \"Address\": \"158 Barfield Rd\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenUsingCustomDateTimeConverter_ThenDateTimeFormatApplied()
        {
            // arrange
            var options = new JsonSerializerOptions();
            options.Converters.Add(new GeneralDateTimeConverter());

            var obj = new
            {
                DateCreated = new DateTime(2017, 8, 24)
            };

            // act
            var jsonString = JsonSerializer.Serialize(obj, options);

            // assert
            Assert.AreEqual("{\"DateCreated\":\"8/24/2017 12:00:00 AM\"}", jsonString);
        }

        [TestMethod]
        public void WhenJsonConverterAttribute_ThenDateTimeFormatApplied()
        {
            // arrange
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var obj = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                BirthDate = new DateTime(2017, 8, 24)
            };

            // act
            var jsonString = JsonSerializer.Serialize(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"FirstName\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\",{Environment.NewLine}  \"BirthDate\": \"8/24/2017 12:00:00 AM\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenReferenceLoop_ThenThrowsException()
        {
            // arrange
            var employee = new Employee { FirstName = "John", LastName = "Smith" };
            var department = new Department { Name = "Human Resources" };
            employee.Department = department;
            department.Staff.Add(employee);

            // act & assert
            Assert.ThrowsException<JsonException>(() => JsonSerializer.Serialize(employee));
        }

        [TestMethod]
        public void WhenReferenceLoop_ThenPreserveReferences()
        {
            // arrange
            var employee = new Employee { FirstName = "John", LastName = "Smith" };
            var department = new Department { Name = "Human Resources" };
            employee.Department = department;
            department.Staff.Add(employee);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            // act
            var jsonString = JsonSerializer.Serialize(department, options);

            // assert
            Assert.AreEqual("{\"$id\":\"1\",\"Name\":\"Human Resources\",\"Staff\":{\"$id\":\"2\",\"$values\":[{\"$id\":\"3\",\"FirstName\":\"John\",\"LastName\":\"Smith\",\"Department\":{\"$ref\":\"1\"}}]}}", jsonString);
        }

        [TestMethod]
        public void WhenReferenceLoop_ThenIgnoreCycles()
        {
            // arrange
            var employee = new Employee { FirstName = "John", LastName = "Smith" };
            var department = new Department { Name = "Human Resources" };
            employee.Department = department;
            department.Staff.Add(employee);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            // act
            var jsonString = JsonSerializer.Serialize(department, options);

            // assert
            Assert.AreEqual("{\"Name\":\"Human Resources\",\"Staff\":[{\"FirstName\":\"John\",\"LastName\":\"Smith\",\"Department\":null}]}", jsonString);
        }
    }
}