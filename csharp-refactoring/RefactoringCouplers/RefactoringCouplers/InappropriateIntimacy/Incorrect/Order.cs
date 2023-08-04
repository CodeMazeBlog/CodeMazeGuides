namespace RefactoringCouplers.InappropriateIntimacy.Incorrect;

public class Order
{
    public string OrderNumber { get; set; }
    public bool IsFinalized { get; private set; }

    public void ProcessOrder(Customer customer)
    {
        try
        {
            customer.CheckIfActive();
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Order can't be processed due to inactive user.");

            return;
        }

        customer.FinalizedOperations.Add(OrderNumber);
        IsFinalized = true;
    }
}
