namespace Tests.Create
{
    [TestClass]
    public class CreateXMLUsingLinqTests
    {
        [TestMethod]
        public void CreateSimpleXML_WhenCalled_ShouldReturnStringWithFirstNameAsElement()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXMLUsingLinq();

            var result = createXml.CreateSimpleXML(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "<firstName>John</firstName>");
        }

        [TestMethod]
        public void CreateSimpleXMLWithAttributes_WhenCalled_ShouldReturnStringWithFirstNameAsAttribute()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXMLUsingLinq();

            var result = createXml.CreateSimpleXMLWithAttributes(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "firstName=\"John\"");
        }

        [TestMethod]
        public void CreateXMLWithNamespace_WhenCalled_ShouldReturnStringWithNamespace()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXMLUsingLinq();

            var result = createXml.CreateXMLWithNamespace(person);

            StringAssert.Contains(result, "<person xmlns:xsi=\"https://www.code-maze.com/sample-schema\"");
        }

        [TestMethod]
        public void CreateXMLWithNamespace2_WhenCalled_ShouldReturnStringWithNamespaces()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));
            var createXml = new CreateXMLUsingLinq();

            var result = createXml.CreateXMLWithNamespace2(person);

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
            var createXml = new CreateXMLUsingLinq();

            var result = createXml.CreateAnArrayOfPeople(people);

            var numberOfElements = result.Split("<person>").Length - 1;

            Assert.AreEqual(numberOfPersons, numberOfElements);
        }

        [TestMethod]
        public void CreateSimpleXML_Comments_WhenCalled_ShouldReturnStringWithFirstNameAsElement()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));

            var result = CreateXMLUsingLinq.CreateSimpleXML_Comments(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "<firstName>John</firstName>");
        }

        [TestMethod]
        public void CreateSimpleXMLWithXmlDeclaration_WhenCalled_ShouldReturnStringWithXMLDeclaration()
        {
            var person = new Person("John", "Doe", "john.doe@code-maze.com", new DateTime(1980, 4, 13));

            var result = CreateXMLUsingLinq.CreateSimpleXMLWithXmlDeclaration(person);

            StringAssert.Contains(result, "<person>");
            StringAssert.Contains(result, "<?xml version=\"1.0\" encoding=\"utf-16\"?>");
        }
    }
}
