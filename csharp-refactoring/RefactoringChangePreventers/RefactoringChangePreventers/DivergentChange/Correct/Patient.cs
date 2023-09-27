namespace RefactoringChangePreventers.DivergentChange.Correct;

public class Patient
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string InsuranceNumber { get; private set; }
    public List<string> TreatmentHistory { get; private set; }

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
}