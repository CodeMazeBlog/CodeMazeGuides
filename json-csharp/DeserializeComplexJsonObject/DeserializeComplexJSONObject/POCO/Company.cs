namespace DeserializeComplexJSONObject.POCO
{
    public class Company
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<Cofounder>? Cofounders { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
