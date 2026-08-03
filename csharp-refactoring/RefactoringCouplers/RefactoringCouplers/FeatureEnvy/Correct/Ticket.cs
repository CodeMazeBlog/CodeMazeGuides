namespace RefactoringCouplers.FeatureEnvy.Correct;

public class Ticket
{
    public bool IsAvailable { get; private set; }
    public int Price { get; init; }

    public Ticket(bool available, int price)
    {
        IsAvailable = available;
        Price = price;
    }

    private bool CanAfford(int points)
    {
        return points >= Price;
    }

    public int TryToBuyTicket(int points)
    {
        if (!IsAvailable || !CanAfford(points))
        {
            return 0;
        }
        IsAvailable = false;

        return Price;
    }
}