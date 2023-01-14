using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.PrimitiveObsession.Correct;

namespace Tests
{
    [TestClass]
    public class DeveloperSpecializationTests
    {
        [TestMethod]
        [DataRow(DeveloperSpecialization.Frontend, DeveloperSpecialization.Frontend)]
        [DataRow(DeveloperSpecialization.Backend, DeveloperSpecialization.Backend)]
        [DataRow(DeveloperSpecialization.FullStack, DeveloperSpecialization.FullStack)]
        public void Create_ValidInput_ReturnsCorrectSpecialization(int input, int expected)
        {
            // Arrange
            var developerSpecialization = DeveloperSpecialization.Create(input);

            // Act
            var specialization = developerSpecialization.Specialization;

            // Assert
            Assert.AreEqual(expected, specialization);
        }

        [TestMethod]
        public void Create_InvalidInput_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var invalidInput = 100;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                DeveloperSpecialization.Create(invalidInput);
            });
        }
    }
}