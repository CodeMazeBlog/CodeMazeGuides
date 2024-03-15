using System.Collections.ObjectModel;

namespace AggregateDesign.Domain;

public class Order
{
    internal List<OrderItem> _items = new();

    public long OrderId { get; private set; }

    public DateTime CreationDate { get; private set; }

    public decimal PaidAmount { get; private set; }

    public DateTime? ShippingDate { get; private set; }

    public OrderStatus Status { get; private set; }

    public Order()
    {
        Status= OrderStatus.PendingPayment;
        CreationDate= DateTime.UtcNow;
    }

    public IReadOnlyCollection<OrderItem> Items => new ReadOnlyCollection<OrderItem>(_items);

    public decimal OrderTotal => _items.Sum(x => Convert.ToDecimal(x.Quantity) * x.UnitPrice);

    public void AddPayment(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Amount must be positive.");

        if (amount > OrderTotal - PaidAmount) 
            throw new InvalidOperationException("Payment can't exceed order total");

        PaidAmount += amount;
        if (PaidAmount >= OrderTotal)
            Status= OrderStatus.ReadyForShipping;
    }

    public void AddItem(string itemName, uint quantity, decimal unitPrice)
    {
        if (Status != OrderStatus.PendingPayment)
            throw new InvalidOperationException("Can't modify order once payment has been done.");

        _items.Add(new OrderItem(itemName, quantity, unitPrice));
    }

    public void RemoveItem(string itemName)
    {
        if (Status != OrderStatus.PendingPayment)
            throw new InvalidOperationException("Can't modify order once payment has been done.");

        _items.RemoveAll(x => x.ItemName == itemName);
    }

    public void AddQuantity(string itemName, uint quantity) 
        => _items.FirstOrDefault(x => x.ItemName.Equals(itemName))?.AddQuantity(quantity);

    public void WithdrawQuantity(string itemName, uint quantity) 
        => _items.FirstOrDefault(x => x.ItemName.Equals(itemName))?.WithdrawQuantity(quantity);

    public void ShipOrder()
    {
        if (_items.Sum(x => x.Quantity) <= 0)
            throw new InvalidOperationException("Can´t ship an order with no items.");

        if (Status == OrderStatus.PendingPayment)
            throw new InvalidOperationException("Can´t ship order unpaid order.");

        if (Status == OrderStatus.InTransit)
            throw new InvalidOperationException("Order already shipped to customer.");

        ShippingDate = DateTime.Now;
        Status = OrderStatus.InTransit;
    }
}
