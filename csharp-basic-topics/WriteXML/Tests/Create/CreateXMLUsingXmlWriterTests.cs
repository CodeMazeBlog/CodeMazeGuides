namespace Tests.Create
{
    [TestClass]
    public class CreateXmlUsingXmlWriterTests
    {
        [TestMethod]
        public void CreateSimpleXml_WhenCalled_ShouldReturnStringWithFirstNameAsElement()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateSimpleXml(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "<firstName>John</firstName>");
        }

        [TestMethod]
        public void CreateSimpleXmlWithAttributes_WhenCalled_ShouldReturnStringWithFirstNameAsAttribute()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateSimpleXmlWithAttributes(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "firstName=\"John\"");
        }

        [TestMethod]
        public void CreateXmlWithNamespace_WhenCalled_ShouldReturnStringWithNamespace()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateXmlWithNamespace(person);

            StringAssert.Contains(result, "<person xmlns:xsi=\"https://www.code-maze.com/sample-schema\"");
        }

        [TestMethod]
        public void CreateXmlWithNamespace2_WhenCalled_ShouldReturnStringWithNamespaces()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateXmlWithNamespace2(person);

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
        public void NumberOfElements_WhenCreateAnArrayOfPeopleIsCalled_ShouldMatchNumerOfPeopleInArray(int numberOfPersons)
        {
            var people = People.Get(numberOfPersons);
            var createXml = new CreateXmlUsingXmlWriter();

            var result = createXml.CreateAnArrayOfPeople(people);

            var numberOfElements = result.Split("<person>").Length - 1;

            Assert.AreEqual(numberOfPersons, numberOfElements);
        }

        [TestMethod]
        public void CreateWrongXml_WhenCalled_ShouldReturnStringWithWrongXml()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));

            var result = CreateXmlUsingXmlWriter.CreateWrongXml(person);

            StringAssert.Contains(result, "<person>");
            Assert.ThrowsException<XmlException>(() => XDocument.Parse(result));
        }
    }
}
