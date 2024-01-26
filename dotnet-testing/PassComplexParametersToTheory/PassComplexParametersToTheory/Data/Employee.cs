namespace PassComplexParametersToTheory.Data;

public class Employee
{
    public required int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required bool IsWorkingRemotely { get; set; }
    public virtual required Address Address { get; set; }
}
