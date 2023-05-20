using RefactoringChangePreventers.DivergentChange.Correct;

namespace RefactoringChangePreventersTests;

[TestClass]
public class TreatmentHistoryExporterUnitTests
{
    [TestMethod]
    public void WhenExportingTreatmentHistory_ThenCsvFileWithTreatmentsShouldBeCreated()
    {
        // Arrange
        var fileName = "test.csv";
        var treatments = new List<string> { "Cough", "Fever", "Flu" };
        var exporter = new CsvTreatmentHistoryExporter();

        // Act
        exporter.ExportTreatmentHistory(fileName, treatments);

        // Assert
        Assert.IsTrue(File.Exists(fileName));
        var lines = File.ReadAllLines(fileName);
        Assert.AreEqual(treatments.Count, lines.Length);
        CollectionAssert.AreEqual(treatments, lines);
        File.Delete(fileName);
    }

    [TestMethod]
    public void WhenExportingTreatmentHistoryToJson_ThenJsonFileWithCorrectDataShouldBeCreated()
    {
        // Arrange
        var exporter = new JsonTreatmentHistoryExporter();
        var treatments = new List<string> { "Flu", "Cold", "Broken leg" };
        var fileName = "test.json";

        // Act
        exporter.ExportTreatmentHistory(fileName, treatments);

        // Assert
        Assert.IsTrue(File.Exists(fileName), "File was not created.");
        var json = File.ReadAllText(fileName);
        var expectedJson = "[\"Flu\",\"Cold\",\"Broken leg\"]";
        Assert.AreEqual(expectedJson, json, "Exported JSON does not match expected JSON.");
        File.Delete(fileName);
    }
}