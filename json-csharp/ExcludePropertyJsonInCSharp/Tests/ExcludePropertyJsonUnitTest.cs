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
            var json = MicrosoftSerializer.ExcludePropertyJsonIgnore(Program.Person);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingNewtonsoftJsonIgnore_ThenReturnRemainingProperties()
        {
            var json = NewtonsoftSerializer.ExcludePropertyJsonIgnore(Program.PersonNewtonsoft);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenUsingDataContract_ThenReturnDataMemberProperties()
        {
            var json = NewtonsoftSerializer.IncludePropertyDataContract(Program.Customer);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"John\",{Environment.NewLine}  \"LastName\": \"Smith\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenExcludeAllNullProperties_ThenReturnOnlyValuedOrDefaultProperties()
        {
            var json = MicrosoftSerializer.ExcludeAllNullProperties(Program.Book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\",{Environment.NewLine}  \"Sells\": 0{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenExcludeAllNullPropertiesWithNewtonsoft_ThenReturnOnlyValuedOrDefaultProperties()
        {
            var json = NewtonsoftSerializer.ExcludeAllNullProperties(Program.Book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\",{Environment.NewLine}  \"Sells\": 0{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenExcludeAllDefaultProperties_ThenReturnOnlyValuedProperties()
        {
            var json = MicrosoftSerializer.ExcludeAllDefaultProperties(Program.Book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenExcludeAllDefaultPropertiesWithNewtonsoft_ThenReturnOnlyValuedProperties()
        {
            var json = NewtonsoftSerializer.ExcludeAllDefaultProperties(Program.Book);

            var expectedResult = $"{{{Environment.NewLine}  \"Id\": 1,{Environment.NewLine}  \"Title\": \"Dracula\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenExcludeUsingContractResolver_ThenReturnNotIgnoredPropertiesNames()
        {
            var json = NewtonsoftSerializer.ExcludeUsingContractResolver(Program.Movie);

            var expectedResult = $"{{{Environment.NewLine}  \"Name\": \"Titanic\",{Environment.NewLine}  \"Description\": \"It is based on accounts of the sinking of the RMS Titanic\"{Environment.NewLine}}}";

            Assert.AreEqual(expectedResult, json);
        }
    }
}