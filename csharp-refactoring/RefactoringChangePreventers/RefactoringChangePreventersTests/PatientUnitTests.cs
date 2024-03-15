using RefactoringChangePreventers.DivergentChange.Correct;

namespace RefactoringChangePreventersTests;

[TestClass]
public class PatientUnitTests
{
    [TestMethod]
    public void WhenAddingTreatment_ThenTreatmentShouldBeAddedToTreatmentHistory()
    {
        // Arrange
        var patient = new Patient("John", "Doe", "12345");
        var treatment = "Cough";

        // Act
        patient.AddTreatment(treatment);

        // Assert
        Assert.IsTrue(patient.TreatmentHistory.Contains(treatment));
    }
}