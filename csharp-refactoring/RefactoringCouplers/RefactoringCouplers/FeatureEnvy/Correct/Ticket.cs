namespace RefactoringCouplers.FeatureEnvy.Correct;
public class Ticket
{
    public Ticket(bool available, int price)
    {
        IsAvailable = available;
        Price = price;
    }

    public bool IsAvailable { get; private set; }
    private int Price { get; init; }

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