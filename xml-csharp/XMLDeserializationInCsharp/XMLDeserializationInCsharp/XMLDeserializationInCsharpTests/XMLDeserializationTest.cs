using System;
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
            var xmlData = "<Person>" +
                          "<Name>John Doe</Name>" +
                          "<Age>30</Age>" +
                          "</Person>";
            var expectedPerson = new Person { Name = "Jane Smith", Age = 25 };

            // Act
            var actualPerson=Program.DeserializeXmlData<Person>(xmlData);

            // Assert
            Assert.AreEqual(expectedPerson.Name, actualPerson.Name);
            Assert.AreEqual(expectedPerson.Age, actualPerson.Age);
        }

        [TestMethod]
        public void When_DeserializingcomplexXML_Then_ReturnBooks()
        {
            // Arrange
            var complexXML = "<Library>" +
                              "<Books><Book>" +
                              "<Title>The Catcher in the Rye</Title>" +
                              "<Author>J.D. Salinger</Author>" +
                              "</Book>" +
                              "<Book>" +
                              "<Title>To Kill a Mockingbird</Title>" +
                              "<Author>Harper Lee</Author>" +
                              "</Book>" +
                              "</Books>" +
                              "</Library>";

            // Act
            var library=Program.DeserializeXmlData<Library>(complexXML);

            // Assert
            Assert.IsNotNull(library);
            Assert.IsNotNull(library.Books);
            Assert.AreEqual(2,library.Books.Count);

            Assert.AreEqual("The Catcher in the Rye", library.Books[0].Title);
            Assert.AreEqual("J.D. Salinger", library.Books[0].Author);

            Assert.AreEqual("To Kill a Mockingbird", library.Books[1].Title);
            Assert.AreEqual("Harper Lee", library.Books[1].Author);

        }
    }
}