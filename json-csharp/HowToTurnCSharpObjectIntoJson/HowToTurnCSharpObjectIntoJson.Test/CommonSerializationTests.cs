using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Text.Json;

namespace HowToTurnCSharpObjectIntoJson.Test
{
    [TestClass]
    public class CommonSerializationTests
    {
        [TestMethod]
        public void WhenSerializingAnonymousObject_ThenReturnsCorrectJson()
        {
            // arrange
            var optionsSystem = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var optionsNewtonsoft = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            // act
            var obj = new
            {
                FirstName = "John",
                LastName = "Smith"
            };

            // System.Text.Json
            var jsonStringSystem = System.Text.Json.JsonSerializer.Serialize(obj, optionsSystem);

            // Newtonsoft
            var jsonStringNewtonsoft = JsonConvert.SerializeObject(obj, optionsNewtonsoft);

            // assert
            var expectedOutput = $"{{{Environment.NewLine}  \"FirstName\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";
            Assert.AreEqual(expectedOutput, jsonStringSystem);
            Assert.AreEqual(expectedOutput, jsonStringNewtonsoft);
        }

        [TestMethod]
        public void WhenSerializingDynamicObject_ThenReturnsCorrectJson()
        {
            // arrange
            var optionsSystem = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var optionsNewtonsoft = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            // act
            dynamic dynObj = new ExpandoObject();
            dynObj.Name = "Corey Richards";
            dynObj.Address = "3519 Woodburn Rd";

            // System.Text.Json
            var jsonStringSystem = System.Text.Json.JsonSerializer.Serialize(dynObj, optionsSystem);

            // Newtonsoft
            var jsonStringNewtonsoft = JsonConvert.SerializeObject(dynObj, optionsNewtonsoft);

            // assert
            var expectedOutput = $"{{{Environment.NewLine}  \"Name\": \"Corey Richards\",{Environment.NewLine}  \"Address\": \"3519 Woodburn Rd\"{Environment.NewLine}}}";
            Assert.AreEqual(expectedOutput, jsonStringSystem);
            Assert.AreEqual(expectedOutput, jsonStringNewtonsoft);
        }
    }
}
