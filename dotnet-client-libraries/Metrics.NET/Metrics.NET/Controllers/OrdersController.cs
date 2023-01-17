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
    private readonly Counter<int> _counter;
    private readonly Histogram<decimal> _histogram;
    private readonly ObservableGauge<int> _observableGauge;

    private readonly List<Order> _orders = new();
    private readonly List<ComputerComponent> _computerComponents = new();

    public OrdersController()
    {
        _counter = _meter.CreateCounter<int>("total-computer-components", "ComputerComponents");
        _histogram = _meter.CreateHistogram<decimal>("orders-price", "Euros", "Distribution of orders price");
        _observableGauge = _meter.CreateObservableGauge<int>("total-orders", () => new[] { new Measurement<int>(_orders.Count) });
    }

    [HttpPost("create-component")]
    public IActionResult CreateComputerComponent(string name, decimal price)
    {
        var component = new ComputerComponent 
        { 
            Id = _computerComponents.Count,
            Name = name, 
            Price = price 
        };

        _computerComponents.Add(component);
        _counter.Add(1, KeyValuePair.Create<string, object?>("ComponentPrice", price));

        return Ok(component);
    }

    [HttpPost("create-order")]
    public IActionResult CreateOrder([FromBody]List<int> componentIds)
    {
        var order = new Order
        {
            Id = _orders.Count,
            Items = _computerComponents.Where(c => componentIds.Contains(c.Id)).ToList()
        };

        _orders.Add(order);

        return Ok(order);
    }

    [HttpPost("{orderId:int}/{componentId:int}")]
    public IActionResult AddComputerComponentToOrder(int orderId, int componentId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            return NotFound($"OrderId {orderId} not found");
        }

        order.Items.Add(_computerComponents.First(c => c.Id == componentId));
        return Ok(order);
    }

    [HttpPost("checkout")]
    public IActionResult Checkout(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            return NotFound($"OrderId {orderId} not found");
        }

        _histogram.Record(order.TotalPrice);
        return Ok();
    }
}
