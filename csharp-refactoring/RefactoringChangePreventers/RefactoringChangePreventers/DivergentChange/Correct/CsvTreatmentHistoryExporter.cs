namespace RefactoringChangePreventers.DivergentChange.Correct;

public class CsvTreatmentHistoryExporter : ITreatmentHistoryExporter
{
    public void ExportTreatmentHistory(string fileName, List<string> treatments)
    {
        using var writer = new StreamWriter(fileName);
        foreach (var treatment in treatments)
        {
            writer.WriteLine(treatment);
        }
    }
}