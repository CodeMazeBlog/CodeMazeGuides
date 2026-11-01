namespace HowToFilterAListBasedOnAnotherListInCSharp;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SchoolId { get; set; }
    public string City { get; set; } = string.Empty;

    override public string ToString()
    {
        return $"{Name} from {City}";
    }
}
