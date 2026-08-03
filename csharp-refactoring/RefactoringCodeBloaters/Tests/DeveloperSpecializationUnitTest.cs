using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.PrimitiveObsession.Correct;

namespace Tests
{
    [TestClass]
    public class DeveloperSpecializationUnitTest
    {
        [TestMethod]
        [DataRow(DeveloperSpecialization.Frontend, DeveloperSpecialization.Frontend)]
        [DataRow(DeveloperSpecialization.Backend, DeveloperSpecialization.Backend)]
        [DataRow(DeveloperSpecialization.FullStack, DeveloperSpecialization.FullStack)]
        public void WhenCreatingDeveloperSpecialization_ThenCorrectSpecializationIsReturned(int input, int expected)
        {
            // Arrange
            var developerSpecialization = DeveloperSpecialization.Create(input);

            // Act
            var specialization = developerSpecialization.Specialization;

            // Assert
            Assert.AreEqual(expected, specialization);
        }

        [TestMethod]
        public void GivenInvalidDeveloperSpecializationTypeCode_WhenCreatingDeveloperSpecialization_ThenExceptionIsThrown()
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