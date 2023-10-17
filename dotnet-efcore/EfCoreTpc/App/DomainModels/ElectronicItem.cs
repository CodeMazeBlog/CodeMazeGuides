namespace App.DomainModels;

public class ElectronicItem : Item
{
    public required string Model { get; set; }
    public required string Manufacturer { get; set; }
}