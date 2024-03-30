namespace Order.ViewModels;

public class OrderViewModel
{
    public List<OrderItemViewModel> Items { get; set; } = [];
}

public class OrderItemViewModel
{
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
}
