namespace DateOnlyAndTimeOnlyTypes;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public TimeOnly WorkStartTime { get; set; }

    public TimeOnly WorkEndTime { get; set; }
}