namespace CodeFirstMigration
{
    //model
    public class Customer
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? CardNumber { get; set; }
    }
}
