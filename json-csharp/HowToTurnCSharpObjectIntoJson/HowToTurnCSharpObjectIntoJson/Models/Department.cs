namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Department
    {
        public string? Name { get; set; }
        public IList<Employee> Staff { get; set; } = new List<Employee>();
    }
}
