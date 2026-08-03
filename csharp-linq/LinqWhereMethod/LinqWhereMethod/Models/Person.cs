namespace LinqWhereMethod.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; }
    public List<Pet> Pets { get; set; } = new List<Pet>();

}
