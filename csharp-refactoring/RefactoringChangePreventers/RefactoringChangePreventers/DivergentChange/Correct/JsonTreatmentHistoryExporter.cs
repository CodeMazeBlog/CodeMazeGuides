using System.Text.Json;

namespace RefactoringChangePreventers.DivergentChange.Correct;

public class JsonTreatmentHistoryExporter : ITreatmentHistoryExporter
{
    public void ExportTreatmentHistory(string fileName, List<string> treatments)
    {
        var json = JsonSerializer.Serialize(treatments);
        using var writer = new StreamWriter(fileName);
        writer.Write(json);
    }
}