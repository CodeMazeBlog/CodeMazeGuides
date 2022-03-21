namespace DeserializeComplexJSONObject.POCO
{
    public class Employee
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public int AnualSalary { get; set; }
        public Position? Position { get; set; }
        public List<Benefit>? Benefits { get; set; }
    }
}
