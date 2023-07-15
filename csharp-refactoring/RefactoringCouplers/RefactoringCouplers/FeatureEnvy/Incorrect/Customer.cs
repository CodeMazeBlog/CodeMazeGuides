namespace RefactoringCouplers.FeatureEnvy.Incorrect;
public class Customer
{
    public Customer(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public int Points { get; set; }

    public void SubtractPoints(int points)
    {
        Points -= points;
    }

    public void ExchangePointsToTicket(Ticket ticket)
    {
        if (ticket.IsAvailable && ticket.CanAfford(Points))
        {
            ticket.BuyTicket();
            SubtractPoints(ticket.Price);
        }
    }
}