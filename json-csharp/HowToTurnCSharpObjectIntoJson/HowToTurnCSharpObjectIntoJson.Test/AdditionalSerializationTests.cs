using HowToTurnCSharpObjectIntoJson.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace HowToTurnCSharpObjectIntoJson.Test
{
    [TestClass]
    public class AdditionalSerializationTests
    {
        private static readonly JsonSerializerOptions IndentedOptions = new()
        {
            WriteIndented = true
        };

        [TestMethod]
        public void WhenUsingSourceGeneratedContext_ThenSameJsonString()
        {
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            var jsonString = System.Text.Json.JsonSerializer.Serialize(obj, ProductJsonContext.Default.Product);

            Assert.AreEqual("{\"Name\":\"Red Apples\",\"Stock\":100,\"DateAcquired\":\"2017-08-24T00:00:00\"}", jsonString);
        }

        [TestMethod]
        public void WhenReusingOptionsInstance_ThenJsonIsIndented()
        {
            var obj = new Product
            {
                Name = "Red Apples",
                Stock = 100,
                DateAcquired = DateTime.Parse("2017-08-24")
            };

            var jsonString = System.Text.Json.JsonSerializer.Serialize(obj, IndentedOptions);

            Assert.AreEqual($"{{{Environment.NewLine}  \"Name\": \"Red Apples\",{Environment.NewLine}  \"Stock\": 100,{Environment.NewLine}  \"DateAcquired\": \"2017-08-24T00:00:00\"{Environment.NewLine}}}", jsonString);
        }

        [TestMethod]
        public void WhenNewtonsoftPreservesReferences_ThenJsonHasIdsAndRefs()
        {
            var employee = new Employee { FirstName = "John", LastName = "Smith" };
            var department = new Department { Name = "Human Resources" };
            employee.Department = department;
            department.Staff.Add(employee);

            var options = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            var jsonString = JsonConvert.SerializeObject(department, options);

            Assert.AreEqual("{\"$id\":\"1\",\"Name\":\"Human Resources\",\"Staff\":[{\"$id\":\"2\",\"FirstName\":\"John\",\"LastName\":\"Smith\",\"Department\":{\"$ref\":\"1\"}}]}", jsonString);
        }
    }
}
