namespace RefactoringCouplers.InappropriateIntimacy.Incorrect;

public class Customer
{
    public bool IsActive { get; set; }
    public ICollection<string> FinalizedOperations { get; set; } = new List<string>();

    public void CheckIfActive()
    {
        if (!IsActive)
        {
            throw new InvalidOperationException("Customer is currently inactive.");
        }
    }
}