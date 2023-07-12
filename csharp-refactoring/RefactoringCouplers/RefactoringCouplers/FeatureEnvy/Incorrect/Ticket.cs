namespace RefactoringCouplers.FeatureEnvy.Incorrect;
public class Ticket
{
    public Ticket(bool available, int price)
    {
        Available = available;
        Price = price;
    }

    private bool Available { get; set; }
    public int Price { get; init; }

    public bool IsAvailable()
    {
        return Available;
    }

    public bool CanAfford(int points)
    {
        return points >= Price;
    }

    public void BuyTicket()
    {
        Available = false;
    }
}