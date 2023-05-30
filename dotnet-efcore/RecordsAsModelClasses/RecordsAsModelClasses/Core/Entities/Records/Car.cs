namespace RecordsAsModelClasses.Core.Entities.Records;

public record Car(string Make, string Model, int Year)
{
    public int Id { get; init; }
}
