namespace Tests.Create
{
    [TestClass]
    public class CreateXmlUsingXmlWriterTests
    {
        [TestMethod]
        public void GivenPerson_WhenCreatingXML_ThenXmlMustHaveFirstNameAsElement()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateSimpleXml(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "<firstName>John</firstName>");
        }

        [TestMethod]
        public void GivenPerson_WhenCreatingXMLWithAttributes_ThenXmlMustHaveFirstNameAsAttribute()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateSimpleXmlWithAttributes(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "firstName=\"John\"");
        }

        [TestMethod]
        public void GivenPerson_WhenCreatingXMLWithNamespace_ThenXmlMustHaveNamespace()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateXmlWithNamespace(person);

            StringAssert.Contains(result, "<person xmlns:xsi=\"https://www.code-maze.com/sample-schema\"");
        }

        [TestMethod]
        public void GivenPerson_WhenCreatingXMLWithNamespaces_ThenXmlMustHaveNamespaces()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateXmlWithThreeNamespaces(person);

            StringAssert.Contains(result, "xmlns:p=\"https://www.code-maze.com/sample-person\"");
            StringAssert.Contains(result, "xmlns:o=\"https://www.code-maze.com/sample-other\"");
            StringAssert.Contains(result, "xmlns:n=\"https://www.code-maze.com/sample-name\"");
            StringAssert.Contains(result, "<n:firstName>John</n:firstName>");
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(50)]
        public void GivenArrayOfPeople_WhenCreatingXML_ThenXmlMustHaveEqualNumberOfElements(int numberOfPersons)
        {
            var people = People.Get(numberOfPersons);
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateAnArrayOfPeople(people);

            var numberOfElements = result.Split("<person>").Length - 1;

            Assert.AreEqual(numberOfPersons, numberOfElements);
        }

        [TestMethod]
        public void GivenPerson_WhenCreatingWrongXml_ThenWrongXmlMustBeCreated()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));

            var result = CreateXmlUsingXmlWriter.CreateWrongXml(person);

            StringAssert.Contains(result, "<person>");
            Assert.ThrowsException<XmlException>(() => XDocument.Parse(result));
        }
    }
}
