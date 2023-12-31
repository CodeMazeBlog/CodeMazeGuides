namespace Tests.Read
{
    [TestClass]
    public class ReadXmlUsingXmlReaderTest
    {
        [TestMethod]
        public void ReadXml_WhenCalledWithValidXml_ShouldReturnElementsWithWhitespaces()
        {
            var result = ReadXmlUsingXmlReader.ReadXml(CreateValidXmlString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Where(e => e.Contains("Whitespace").Equals(true)).Any());
        }

        [TestMethod]
        public void ReadXml_WhenCalledWithInvalidXml_ShouldReturnThrow()
        {
            Assert.ThrowsException<XmlException>(() => ReadXmlUsingXmlReader.ReadXml(CreateInvalidXmlString()));
        }


        [TestMethod]
        public void ReadXmlWithoutWhiteSpace_WhenCalledWithValidXml_ShouldReturnElementsWithoutWhitespaces()
        {
            var result = ReadXmlUsingXmlReader.ReadXmlWithoutWhiteSpace(CreateValidXmlString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(!result.Where(e => e.Contains("Whitespace").Equals(true)).Any());
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(50)]
        public void ReadNamesAndAges_WhenCalled_ShouldReturnEqualNumerOfRows(int numberOfPersons)
        {
            var people = People.Get(numberOfPersons);
            var arrayOfPeople = CreateXMLUsingXmlWriter.CreateAnArrayOfPeople(people);

            var result = ReadXmlUsingXmlReader.ReadNamesAndAges(arrayOfPeople);

            Assert.AreEqual(numberOfPersons, result.Count());
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
