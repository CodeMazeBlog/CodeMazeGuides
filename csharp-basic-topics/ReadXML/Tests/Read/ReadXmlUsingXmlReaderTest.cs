namespace Tests.Read
{
    [TestClass]
    public class ReadXmlUsingXmlReaderTest
    {
        [TestMethod]
        public void GivenValidXmlString_WhenCallingReadXml_ThenWhitespacesAreIsReturned()
        {
            var result = ReadXmlUsingXmlReader.ReadXml(CreateValidXmlString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Where(e => e.Contains("Whitespace")).Any());
        }

        [TestMethod]
        public void GivenInvalidXmlString_WhenCallingReadXml_ThenExceptionIsThrown()
        {
            Assert.ThrowsException<XmlException>(() => ReadXmlUsingXmlReader.ReadXml(CreateInvalidXmlString()));
        }


        [TestMethod]
        public void GivenValidXmlString_WhenCallingReadXmlWithoutWhiteSpace_ThenNoWhitespacesAreIsReturned()
        {
            var result = ReadXmlUsingXmlReader.ReadXmlWithoutWhiteSpace(CreateValidXmlString());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsTrue(!result.Where(e => e.Contains("Whitespace")).Any());
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(50)]
        public void GivenNumberOfPersons_WhenCallingCreateAnArrayOfPeople_ThenSameNumberOfPeopleIsGenerated(int numberOfPersons)
        {
            var people = People.Get(numberOfPersons);
            var arrayOfPeople = CreateXmlUsingXmlWriter.CreateAnArrayOfPeople(people);

            var result = ReadXmlUsingXmlReader.ReadNamesAndAges(arrayOfPeople);

            Assert.AreEqual(numberOfPersons, result.Count());
        }

        private static string CreateValidXmlString()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var personXml = CreateXmlUsingXmlWriter.CreateSimpleXml(person);
            return personXml;
        }

        private static string CreateInvalidXmlString()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var personXml = CreateXmlUsingXmlWriter.CreateWrongXml(person);
            return personXml;
        }
    }
}
