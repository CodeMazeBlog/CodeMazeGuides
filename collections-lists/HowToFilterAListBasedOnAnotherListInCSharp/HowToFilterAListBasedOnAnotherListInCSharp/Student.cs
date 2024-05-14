namespace HowToFilterAListBasedOnAnotherListInCSharp;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SchoolId { get; set; }
    public string City { get; set; }

    override public string ToString()
    {
        return $"{Name} from {City}";
    }
}
