namespace PassComplexParametersToTheory.Data;

public class Address
{
    public required int Id { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required int HouseNumber { get; set; }
    public required bool IsMainAddress { get; set; }
}
