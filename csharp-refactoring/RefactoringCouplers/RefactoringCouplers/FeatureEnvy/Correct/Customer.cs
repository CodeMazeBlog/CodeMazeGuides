namespace RefactoringCouplers.FeatureEnvy.Correct;

public class Customer
{
    public string Name { get; init; }
    public int Points { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void SubtractPoints(int points)
    {
        Points -= points;
    }

    public void ExchangePointsToTicket(Ticket ticket)
    {
        var usedPoints = ticket.TryToBuyTicket(Points);
        SubtractPoints(usedPoints);
    }
}