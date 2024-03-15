namespace RefactoringCouplers.MiddleMan;

public class Ticket
{
    public string Name { get; init; }
    public DateTime Date { get; init; }

    public Ticket(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }
}