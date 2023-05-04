using System.Text.Json;

namespace RefactoringChangePreventers.DivergentChange.Correct;

public class TreatmentHistoryExporter
{
    public void ExportTreatmentHistoryToCsv(string fileName, List<string> treatments)
    {
        using var writer = new StreamWriter(fileName);
        foreach (var treatment in treatments)
        {
            writer.WriteLine(treatment);
        }
    }

    public void ExportTreatmentHistoryToJson(string fileName, List<string> treatments)
    {
        var json = JsonSerializer.Serialize(treatments);
        using var writer = new StreamWriter(fileName);
        writer.Write(json);
    }
}