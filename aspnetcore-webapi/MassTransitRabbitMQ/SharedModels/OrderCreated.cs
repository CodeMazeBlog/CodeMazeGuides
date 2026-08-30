namespace SharedModels
{
    public interface OrderCreated
    {
        int Id { get; }

        string ProductName { get; }

        decimal Price { get; }

        int Quantity { get; }
    }   
}