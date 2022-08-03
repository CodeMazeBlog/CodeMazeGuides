namespace SimpleInjectorExample.Models;

#nullable disable

public class Address
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string City { get; set; }
    public string Zone { get; set; }
    public int BuildingNumber { get; set; }
}
