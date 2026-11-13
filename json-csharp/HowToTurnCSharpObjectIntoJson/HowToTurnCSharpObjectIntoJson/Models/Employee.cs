namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Employee
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Department? Department { get; set; }
    }
}
