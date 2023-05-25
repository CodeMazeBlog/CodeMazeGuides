namespace RecordsAsModelClasses.Core.Entities.Records;

public record Car
{
    private static int _currentId = 1;
    public int Id { get; init; }
    public string Make { get; init; }
    public string Model { get; init; }
    public int Year { get; init; }

    public Car(string make, string model, int year)
    {
        Id = _currentId++;
        Make = make;
        Model = model;
        Year = year;
    }
}
