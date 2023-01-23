using ActionAndFunctionConsole.Services;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ConverterService converterService = new ConverterService((_) => _.ToUpper());
            string result = converterService.Convert("toupperexample");
            Assert.AreEqual("TOUPPEREXAMPLE", result);
        }
    }
}