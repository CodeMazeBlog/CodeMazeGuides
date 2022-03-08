namespace QueueInCSharp.Models;

public class Order
{
    public Order(string clientName, string[] productNames, int totalPrice) => (ClientName, ProductNames, TotalPrice) = (clientName, productNames, totalPrice);
    public string ClientName { get; set; }
    public string[] ProductNames { get; set; }
    public int TotalPrice { get; set; }
}