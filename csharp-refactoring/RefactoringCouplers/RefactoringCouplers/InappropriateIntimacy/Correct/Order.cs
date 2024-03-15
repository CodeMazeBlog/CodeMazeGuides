namespace RefactoringCouplers.InappropriateIntimacy.Correct;

public class Order
{
    public string OrderNumber { get; set; }
    public bool IsFinalized { get; private set; }

    public void ProcessOrder(Customer customer)
    {
        var orderFinalized = customer.FinalizeOrder(OrderNumber);
        IsFinalized = orderFinalized;
    }
}