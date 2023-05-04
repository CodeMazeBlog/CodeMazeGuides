using RefactoringChangePreventers.DivergentChange.Correct;

namespace RefactoringChangePreventersTests;

[TestClass]
public class PatientTests
{
    [TestMethod]
    public void AddTreatment_ShouldAddTreatmentToTreatmentHistory()
    {
        // Arrange
        var patient = new Patient("John", "Doe", "12345");
        var treatment = "Cough";

        // Act
        patient.AddTreatment(treatment);

        // Assert
        Assert.IsTrue(patient.TreatmentHistory.Contains(treatment));
    }

    [TestMethod]
    public void GetPatientData_ShouldReturnFormattedPatientData()
    {
        // Arrange
        var patient = new Patient("John", "Doe", "12345");
        var expected = "Name: John Doe, Insurance Number: 12345";

        // Act
        var result = patient.GetPatientData();

        // Assert
        Assert.AreEqual(expected, result);
    }
}