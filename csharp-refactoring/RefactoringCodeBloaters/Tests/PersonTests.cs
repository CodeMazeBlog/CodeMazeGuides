using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.PrimitiveObsession.Correct;

namespace Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Constructor_ValidInput_PropertiesAreSet()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var person = new Person(firstName, lastName);

            // Assert
            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(lastName, person.LastName);
            Assert.IsNull(person.Address);
        }

        [TestMethod]
        public void AssignAddress_ValidInput_AddressIsAssigned()
        {
            // Arrange
            var person = new Person("John", "Doe");
            var address = new Address
            {
                StreetName = "123 Main St",
                City = "Anytown",
                Country = "USA"
            };

            // Act
            person.AssignAddress(address);

            // Assert
            Assert.AreEqual(address, person.Address);
        }
    }
}