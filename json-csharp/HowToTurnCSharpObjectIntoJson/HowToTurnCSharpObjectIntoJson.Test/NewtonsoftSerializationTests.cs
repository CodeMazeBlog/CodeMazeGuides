using HowToTurnCSharpObjectIntoJson.Converters;
using HowToTurnCSharpObjectIntoJson.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace HowToTurnCSharpObjectIntoJson.Test
{
    [TestClass]
    public class NewtonsoftSerializationTests
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
            var jsonString = JsonConvert.SerializeObject(obj);

            // assert
            Assert.AreEqual("{\"Name\":\"Red Apples\",\"Stock\":100,\"DateAcquired\":\"2017-08-24T00:00:00\"}", jsonString);
        }

        [TestMethod]
        public void WhenUsingFormattingIndented_ThenPrintJsonIndented()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            // act
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Red Apples\",{Environment.NewLine}  \"Stock\": 100,{Environment.NewLine}  \"DateAcquired\": \"2017-08-24T00:00:00\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenSettingContractResolver_ThenJsonHasCamelCaseProperties()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            // act
            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonString = JsonConvert.SerializeObject(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"name\": \"Red Apples\",{Environment.NewLine}  \"stock\": 100,{Environment.NewLine}  \"dateAcquired\": \"2017-08-24T00:00:00\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenSettingNullValueHandling_ThenNullValuesIgnored()
        {
            // arrange
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = null,
                DateAcquired = null
            };

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            // act
            var jsonString = JsonConvert.SerializeObject(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Red Apples\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenJsonIgnoreAttribute_ThenPropertyIgnored()
        {
            // arrange
            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var obj = new CustomerNewtonsoft
            {
                Name = "Pumpkins And Roses",
                Address = "158 Barfield Rd",
                FinancialRating = 4.5M
            };

            // act
            var jsonString = JsonConvert.SerializeObject(obj, options);

            // assert
            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Pumpkins And Roses\",{Environment.NewLine}  \"Address\": \"158 Barfield Rd\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenUsingCustomDateTimeConverter_ThenDateTimeFormatApplied()
        {
            // arrange
            var obj = new
            {
                DueDate = new DateTime(2017, 8, 24)
            };

            // act
            var jsonString = JsonConvert.SerializeObject(obj, new GeneralDateTimeNewtonsoftConverter());

            // assert
            Assert.AreEqual($"{{\"DueDate\":\"8/24/2017 12:00:00 AM\"}}", jsonString);
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
            Assert.ThrowsException<JsonSerializationException>(() => JsonConvert.SerializeObject(employee));

        }

        [TestMethod]
        public void WhenReferenceLoop_ThenIgnoreLoops()
        {
            // arrange
            var employee = new Employee { FirstName = "John", LastName = "Smith" };
            var department = new Department { Name = "Human Resources" };
            employee.Department = department;
            department.Staff.Add(employee);

            var options = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            // act
            var jsonString = JsonConvert.SerializeObject(department, options);

            // assert
            Assert.AreEqual($"{{\"Name\":\"Human Resources\",\"Staff\":[{{\"FirstName\":\"John\",\"LastName\":\"Smith\"}}]}}", jsonString);
        }
    }
}
