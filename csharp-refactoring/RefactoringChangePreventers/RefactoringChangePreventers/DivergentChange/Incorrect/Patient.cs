namespace RefactoringChangePreventers.DivergentChange.Incorrect;

public class Patient
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<string> TreatmentHistory { get; set; }

    public Patient(string firstName, string lastName, string insuranceNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        TreatmentHistory = new List<string>();
    }

    public void AddTreatment(string treatment)
    {
        TreatmentHistory.Add(treatment);
    }

    public string GetPatientData()
    {
        return $"Name: {FirstName} {LastName}";
    }

    public void ExportTreatmentHistory(string fileName)
    {
        using var writer = new StreamWriter(fileName);
        foreach (var treatment in TreatmentHistory)
        {
            writer.WriteLine(treatment);
        }
    }
}
