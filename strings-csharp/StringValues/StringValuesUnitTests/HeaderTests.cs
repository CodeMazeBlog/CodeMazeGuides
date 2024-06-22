using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringValuesUnitTests
{
    [TestClass]
    public class HeaderTests
    {
        private static readonly string[] expected = ["value1", "value2"];

        [TestMethod]
        public void GivenExistingHeader_WhenNewValueAdded_ShouldStoreMultipleValues()
        {
            var headers = new StringValuesImplementation();
            headers.AddHeader("MyHeader", "value1");
            headers.AddHeader("MyHeader", "value2");
            var values = headers.GetHeaderValues("MyHeader");
            Assert.AreEqual(2, values.Count);
            CollectionAssert.AreEqual(expected, values.ToArray());
        }

        [TestMethod]
        public void GivenExistingHeaderInLegacyImplementation_WhenNewValueAdded_ShouldStoreMultipleValues()
        {
            var headers = new LegacyImplementation();
            headers.AddHeader("MyHeader", "value1");
            headers.AddHeader("MyHeader", "value2");
            var values = headers.GetHeaderValues("MyHeader");
            Assert.AreEqual(2, values.Length);
            CollectionAssert.AreEqual(expected, values);
        }

        [TestMethod]
        public void GivenExistingHeaderInNaiveImplementation_WhenNewValueAdded_ShouldStoreMultipleValues()
        {
            var headers = new NaiveImplementation();
            headers.AddHeader("MyHeader", "value1");
            headers.AddHeader("MyHeader", "value2");
            var values = headers.GetHeaderValues("MyHeader");
            Assert.AreEqual(2, values.Length);
            CollectionAssert.AreEqual(expected, values);
        }
    }
}