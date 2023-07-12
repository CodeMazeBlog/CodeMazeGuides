namespace RefactoringCouplers.FeatureEnvy.Correct;
public class Ticket
{
    public Ticket(bool available, int price)
    {
        Available = available;
        Price = price;
    }

    private bool Available { get; set; }
    private int Price { get; init; }

    public bool IsAvailable()
    {
        return Available;
    }

    private bool CanAfford(int points)
    {
        return points >= Price;
    }

    public int BuyTicket(int points)
    {
        if (!IsAvailable() || !CanAfford(points))
        {
            return 0;
        }

        Available = false;
        return Price;
    }
}