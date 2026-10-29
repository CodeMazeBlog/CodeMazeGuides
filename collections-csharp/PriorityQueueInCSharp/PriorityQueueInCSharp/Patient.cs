namespace PriorityQueueInCSharp;

public class Patient
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public Patient(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
