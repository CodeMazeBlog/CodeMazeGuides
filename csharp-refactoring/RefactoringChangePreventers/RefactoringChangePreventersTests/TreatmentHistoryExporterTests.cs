using RefactoringChangePreventers.DivergentChange.Correct;

namespace RefactoringChangePreventersTests;

[TestClass]
public class TreatmentHistoryExporterTests
{
    [TestMethod]
    public void ExportTreatmentHistory_ShouldCreateCsvFileWithTreatments()
    {
        // Arrange
        var fileName = "test.csv";
        var treatments = new List<string> { "Cough", "Fever", "Flu" };
        var exporter = new TreatmentHistoryExporter();

        // Act
        exporter.ExportTreatmentHistoryToCsv(fileName, treatments);

        // Assert
        Assert.IsTrue(File.Exists(fileName));
        var lines = File.ReadAllLines(fileName);
        Assert.AreEqual(treatments.Count, lines.Length);
        CollectionAssert.AreEqual(treatments, lines);
        File.Delete(fileName);
    }

    [TestMethod]
    public void ExportTreatmentHistoryToJson_ShouldCreateJsonFileWithCorrectData()
    {
        // Arrange
        var exporter = new TreatmentHistoryExporter();
        var treatments = new List<string> { "Flu", "Cold", "Broken leg" };
        var fileName = "test.json";

        // Act
        exporter.ExportTreatmentHistoryToJson(fileName, treatments);

        // Assert
        Assert.IsTrue(File.Exists(fileName), "File was not created.");
        var json = File.ReadAllText(fileName);
        var expectedJson = "[\"Flu\",\"Cold\",\"Broken leg\"]";
        Assert.AreEqual(expectedJson, json, "Exported JSON does not match expected JSON.");
        File.Delete(fileName);
    }
}