using System;
using XML_Deserialization;

namespace DeserializationTests
{
    [TestClass]
    public class DeserializeTest
    {
        [TestMethod]
        public void When_DeserializingXmlData_Then_ReturnExpectedPerson()
        {
            //Arrange
            var xmlData = "<Person>" +
                          "<Name>John Doe</Name>" +
                          "<Age>30</Age>" +
                          "</Person>";
            Person expectedPerson = new Person { Name = "Jane Smith", Age = 25 };

            // Act
            Person actualPerson = Program.DeserializeXmlData(xmlData);

            //Assert
            Assert.AreEqual(expectedPerson.Name, actualPerson.Name);
            Assert.AreEqual(expectedPerson.Age, actualPerson.Age);
        }
    }
}