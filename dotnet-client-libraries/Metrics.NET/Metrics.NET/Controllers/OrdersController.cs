using Metrics.NET.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Metrics.NET.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private static readonly Meter _meter = new("Metrics.NET");
    private readonly Counter<int> _computerComponentsCounter;
    private readonly ObservableGauge<int> _totalOrdersGauge;
    private readonly Histogram<int> _componentsPerOrderHistogram;

    private static readonly List<Order> _orders = new();
    private static readonly List<ComputerComponent> _computerComponents = new();

    public OrdersController()
    {
        _computerComponentsCounter = _meter.CreateCounter<int>("total-computer-components", 
            "ComputerComponents", "Total number of computer components");

        _totalOrdersGauge = _meter.CreateObservableGauge("total-orders", () => 
            new Measurement<int>(_orders.Count), "orders", "Current value of orders in progress");

        _componentsPerOrderHistogram = _meter.CreateHistogram<int>("components-per-order", 
            "ComputerComponents", "Distribution of components per order");
    }

    [HttpPost("create-component")]
    public IActionResult CreateComputerComponent(string name, decimal price)
    {
        var component = new ComputerComponent 
        { 
            Id = _computerComponents.Count + 1,
            Name = name, 
            Price = price 
        };

        _computerComponents.Add(component);
        _computerComponentsCounter.Add(1, KeyValuePair.Create<string, object?>("ComponentPrice", price));

        return Ok(component);
    }

    [HttpPost("create-order")]
    public IActionResult CreateOrder([FromBody]List<int> componentIds)
    {
        var order = new Order
        {
            Id = _orders.Count + 1,
            Items = _computerComponents.Where(c => componentIds.Contains(c.Id)).ToList()
        };

        _orders.Add(order);
        return Ok(order);
    }

    [HttpPost("cancel-order/{orderId:int}")]
    public IActionResult CancelOrder(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            return NotFound($"OrderId {orderId} not found");
        }
        _orders.Remove(order);
        return Ok("Order removed");
    }

    [HttpPost("checkout/{orderId:int}")]
    public IActionResult Checkout(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            return NotFound($"OrderId {orderId} not found");
        }

        _componentsPerOrderHistogram.Record(order.Items.Count);
        return Ok("Order checked out");
    }
}
