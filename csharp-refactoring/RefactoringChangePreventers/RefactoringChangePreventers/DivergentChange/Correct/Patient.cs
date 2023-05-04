namespace RefactoringChangePreventers.DivergentChange.Correct;

public class Patient
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string InsuranceNumber { get; set; }
    public List<string> TreatmentHistory { get; set; }

    public Patient(string firstName, string lastName, string insuranceNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        InsuranceNumber = insuranceNumber;
        TreatmentHistory = new List<string>();
    }

    public void AddTreatment(string treatment)
    {
        TreatmentHistory.Add(treatment);
    }

    public string GetPatientData()
    {
        return $"Name: {FirstName} {LastName}, Insurance Number: {InsuranceNumber}";
    }
}