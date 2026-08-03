namespace RefactoringCouplers.InappropriateIntimacy.Correct;

public class Customer
{
    public bool IsActive { get; set; }
    public ICollection<string> FinalizedOperations { get; set; } = new List<string>();

    public bool FinalizeOrder(string orderNumber)
    {
        try
        {
            CheckIfActive();
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Order can't be processed due to inactive user.");

            return false;
        }
        FinalizedOperations.Add(orderNumber);

        return true;
    }

    private void CheckIfActive()
    {
        if (!IsActive)
        {
            throw new InvalidOperationException("Customer is currently inactive.");
        }
    }
}