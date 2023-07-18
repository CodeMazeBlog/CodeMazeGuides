using XMLDeserializationInCsharp;

namespace XMLDeserializationInCsharpTests
{
    [TestClass]
    public class XMLDeserializationTest
    {
        [TestMethod]
        public void When_DeserializingXmlData_Then_ReturnExpectedPerson()
        {
            // Arrange
            var xmlData = @"<Person>
                              <Name>Jane Smith</Name> 
                              <Age>25</Age>
                          </Person>";
            var expectedPerson = new Person { Name = "Jane Smith", Age = 25 };

            // Act
            var actualPerson = Program.DeserializeXmlData<Person>(xmlData);

            // Assert
            Assert.AreEqual(expectedPerson.Name, actualPerson.Name);
            Assert.AreEqual(expectedPerson.Age, actualPerson.Age);
        }

        [TestMethod]
        public void When_DeserializingcomplexXML_Then_ReturnBooks()
        {
            // Arrange
            var complexXML = @"<Library>
                                  <Books>
                                     <Book>
                                       <Title>The Catcher in the Rye</Title>
                                       <Author>J.D. Salinger</Author>
                                     </Book>
                                     <Book>
                                      <Title>To Kill a Mockingbird</Title>
                                      <Author>Harper Lee</Author>
                                     </Book>
                                  </Books>
                               </Library>";

            // Act
            var library = Program.DeserializeXmlData<Library>(complexXML);

            // Assert
            Assert.IsNotNull(library);
            Assert.IsNotNull(library.Books);
            Assert.AreEqual(2, library.Books.Count);

            Assert.AreEqual("The Catcher in the Rye", library.Books[0].Title);
            Assert.AreEqual("J.D. Salinger", library.Books[0].Author);

            Assert.AreEqual("To Kill a Mockingbird", library.Books[1].Title);
            Assert.AreEqual("Harper Lee", library.Books[1].Author);

        }

        [TestMethod]
        public void When_DeserializingXmlData_Then_ReturnPersonrecord()
        {
            // Arrange
            var personXML = @"<PersonRecord>
                                <Name>John Wick</Name>
                                <Age>35</Age>
                            </PersonRecord>";
            var expectedPerson = new PersonRecord { Name = "John Wick", Age = 35 };

            // Act
            var actualPerson = Program.DeserializeXmlData<PersonRecord>(personXML);

            // Assert
            Assert.AreEqual(expectedPerson.Name, actualPerson.Name);
            Assert.AreEqual(expectedPerson.Age, actualPerson.Age);
        }

        [TestMethod]
        public void When_DeserializingXmlData_Then_ReturnBooks()
        {
            // Arrange
            var libraryXML = @"<LibraryRecord>
                                <Books>
                                <BookRecord>
                                    <Title>John Wick : Chapter 4</Title>
                                    <Author>Chad Stahelski</Author>
                                </BookRecord>
                                <BookRecord>
                                    <Title>Keanu Reeves</Title>
                                    <Author>BRZRKR</Author>
                                </BookRecord>
                                </Books>
                          </LibraryRecord>";

            // Act
            var library = Program.DeserializeXmlData<LibraryRecord>(libraryXML);

            // Assert
            Assert.IsNotNull(library);
            Assert.IsNotNull(library.Books);
            Assert.AreEqual(2, library.Books.Count);

            Assert.AreEqual("John Wick : Chapter 4", library.Books[0].Title);
            Assert.AreEqual("Chad Stahelski", library.Books[0].Author);

            Assert.AreEqual("Keanu Reeves", library.Books[1].Title);
            Assert.AreEqual("BRZRKR", library.Books[1].Author);
        }
    }
}