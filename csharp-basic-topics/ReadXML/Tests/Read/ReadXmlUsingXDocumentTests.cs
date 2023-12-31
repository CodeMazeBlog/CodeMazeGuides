namespace Tests.Read
{
    [TestClass]
    public class ReadXmlUsingXDocumentTests
    {
        [TestMethod]
        public void ReadXmlAndCatchErrors_WhenCalledWithValidXml_ShouldReturnPopulatedXDocument()
        {
            var result = ReadXmlUsingXDocument.ReadXmlAndCatchErrors(CreateValidXmlString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Root != null);
            Assert.IsTrue(result.Root.Name == "person");
        }

        [TestMethod]
        public void ReadXmlAndCatchErrors_WhenCalledWithInvalidXml_ShouldReturnEmptyXDocument()
        {
            var result = ReadXmlUsingXDocument.ReadXmlAndCatchErrors(CreateInvalidXmlString());

            Assert.IsNotNull(result);
            Assert.IsNull(result.Root);
        }

        [TestMethod]
        public void TestValidXml_WhenCalled_ShouldReturnStringWithValidXml()
        {
            var result = ReadXmlUsingXDocument.ReadXmlAndCatchErrors(ReadXmlUsingXDocument.TestValidXml());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Root != null);
            Assert.IsTrue(result.Root.Name == "person");
        }

        [TestMethod]
        public void TestInvalidXml_WhenCalled_ShouldReturnStringWithInvalidXml()
        {
            var result = ReadXmlUsingXDocument.ReadXmlAndCatchErrors(ReadXmlUsingXDocument.TestInvalidXml());

            Assert.IsNotNull(result);
            Assert.IsNull(result.Root);
        }

        [TestMethod]
        public void ReadWithElementCollection_WhenCalled_ShouldReturnStringWithNameAndAge()
        {
            var result = ReadXmlUsingXDocument.TestReadWithElementCollection();

            StringAssert.Contains(result, "Name:");
            StringAssert.Contains(result, "Age:");
        }

        [TestMethod]
        public void ReadUsingXPath_WhenCalled_ShouldReturnStringWithNameAndAge()
        {
            var result = ReadXmlUsingXDocument.TestReadWithElementCollection();

            StringAssert.Contains(result, "Name:");
            StringAssert.Contains(result, "Age:");
        }

        private static string CreateValidXmlString()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var personXml = CreateXMLUsingXmlWriter.CreateSimpleXML(person);
            return personXml;
        }

        private static string CreateInvalidXmlString()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var personXml = CreateXMLUsingXmlWriter.CreateWrongXML(person);
            return personXml;
        }
    }
}
