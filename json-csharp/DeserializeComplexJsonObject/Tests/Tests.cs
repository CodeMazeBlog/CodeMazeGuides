using DeserializeComplexJSONObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly MicrosoftDeserializer _microsoftDeserializer;
        private readonly NewtonsoftDeserializer _newtonsoftDeserializer;

        private readonly string _json;

        public Tests()
        {
            _microsoftDeserializer = new();
            _newtonsoftDeserializer = new();

            _json = JsonComplexObject.Json;
        }

        [TestMethod]
        public void WhenRunTheMainMethod_ThenWriteResultsAtTheConsole()
        {
            Program.Main(Array.Empty<string>());

            Assert.AreEqual(1, Program.OutputResult);
        }

        [TestMethod]
        public void GivenAJsonString_WhenUsingGenericSystemTextJson_ThenReturnACompanyInstance()
        {
            var company = _microsoftDeserializer.DeserializeUsingGenericSystemTextJson(_json);

            Assert.IsNotNull(company);
        }

        [TestMethod]
        public void GivenAJsonString_WhenUsingSystemTextJson_ThenReturnACompanyInstance()
        {
            var company = _microsoftDeserializer.DeserializeUsingSystemTextJson(_json);

            Assert.IsNotNull(company);
        }

        [TestMethod]
        public void GivenAJsonString_WhenUsingNewtonsoftJson_ThenReturnACompanyInstance()
        {
            var company = _newtonsoftDeserializer.DeserializeUsingGenericNewtonsoftJson(_json);

            Assert.IsNotNull(company);
        }
    }
}