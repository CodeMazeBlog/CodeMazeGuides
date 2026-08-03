namespace Tests.Read
{
    [TestClass]
    public class ReadXmlUsingXDocumentTests
    {
        [TestMethod]
        public void GivenValidXmlString_WhenCallingReadXmlAndCatchErrors_ThenXmlWithPersonIsGenerated()
        {
            var result = ReadXmlUsingXDocument.ReadXmlAndCatchErrors(ReadXmlUsingXDocument.TestValidXml());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Root != null);
            Assert.IsTrue(result.Root.Name == "person");
        }

        [TestMethod]
        public void GivenInvalidXmlString_WhenCallingReadXmlAndCatchErrors_ThenEmptyXmlIsGenerated()
        {
            var result = ReadXmlUsingXDocument.ReadXmlAndCatchErrors(ReadXmlUsingXDocument.TestInvalidXml());

            Assert.IsNotNull(result);
            Assert.IsNull(result.Root);
        }
    }
}
