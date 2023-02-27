using ExcludePropertyJsonInCSharp;
using ExcludePropertyJsonInCSharp.Serializers;

namespace Tests
{
    [TestClass]
    public class ExcludePropertyJsonUnitTest
    {
        [TestMethod]
        public void WhenUsingJsonIgnore_ThenReturnRemainingProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            MicrosoftSerializer.ExcludePropertyJsonIgnore(Program.person);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenUsingNewtonsoftJsonIgnore_ThenReturnRemainingProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            NewtonsoftSerializer.ExcludePropertyJsonIgnore(Program.personNewtonsoft);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenUsingDataContract_ThenReturnDataMemberProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            NewtonsoftSerializer.IncludePropertyDataContract(Program.customer);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenExcludeAllNullProperties_ThenReturnOnlyValuedOrDefaultProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            MicrosoftSerializer.ExcludeAllNullProperties(Program.book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\",{Environment.NewLine}  \"Sells\": 0{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenExcludeAllNullPropertiesWithNewtonsoft_ThenReturnOnlyValuedOrDefaultProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            NewtonsoftSerializer.ExcludeAllNullProperties(Program.book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\",{Environment.NewLine}  \"Sells\": 0{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenExcludeAllDefaultProperties_ThenReturnOnlyValuedProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            MicrosoftSerializer.ExcludeAllDefaultProperties(Program.book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenExcludeAllDefaultPropertiesWithNewtonsoft_ThenReturnOnlyValuedProperties()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            NewtonsoftSerializer.ExcludeAllDefaultProperties(Program.book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenExcludeUsingContractResolver_ThenReturnNotIgnoredPropertiesNames()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            NewtonsoftSerializer.ExcludeUsingContractResolver(Program.movie);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"Titanic\",\r\n  \"Description\": \"It is based on accounts of the sinking of the RMS Titanic\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, sw.ToString());
        }
    }
}