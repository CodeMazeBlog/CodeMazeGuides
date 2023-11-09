namespace SystemDynamicLinqCoreLibrary
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public string Residence { get; set; }
        public Employer Employer { get; set; }
    }
}