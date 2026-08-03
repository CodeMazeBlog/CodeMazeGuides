namespace RefactoringChangePreventers.DivergentChange.Correct;

public interface ITreatmentHistoryExporter
{
    void ExportTreatmentHistory(string fileName, List<string> treatments);
}