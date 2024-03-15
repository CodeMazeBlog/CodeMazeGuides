namespace PrimaryConstructorsForClassesAndStructs;

public class Doctor(string name, List<string> patients)
{
    public string Name { get; set; } = name;
    public bool IsOverworked => patients.Count >= 5;

    public Doctor(string name)
        : this(name, new List<string>())
    {
    }

    public void AddPatient(string patient) => patients.Add(patient);
}
