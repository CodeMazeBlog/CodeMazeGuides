namespace LinqWhereMethod.Models;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
