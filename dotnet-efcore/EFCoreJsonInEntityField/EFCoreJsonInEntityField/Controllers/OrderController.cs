using EFCoreJsonInEntityField.Filters;
using EFCoreJsonInEntityField.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreJsonInEntityField.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }

        [HttpPost]
        [CustomExceptionFilter]
        public async Task<IActionResult> AddOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(new {action = nameof(OrderController.GetOrderById), id = order.Id },order);
        }

        [HttpPatch("{id}")]
        [RestrictPatchOperationsAttribute<Order>]
        [CustomExceptionFilter]
        public async Task<IActionResult> UpdateOrder(Guid id, JsonPatchDocument<Order> patch)
        {
            var findOrder = _context.Orders.Where(p => p.Id == id).FirstOrDefault();
            if (findOrder is null)
                return NotFound();

            patch.ApplyTo(findOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/shipments")]
        [CustomExceptionFilter]
        public async Task<IActionResult> AddShipmentToOrder(Guid id, Shipment shipment)
        {
            var findOrder = _context.Orders.Where(p => p.Id == id).FirstOrDefault();
            if (findOrder is null)
                return NotFound();

            findOrder.ShippingInfo.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(new { action = nameof(OrderController.GetOrderById), id = findOrder.Id }, findOrder);
        }

        [HttpPost("{id}/deliveries")]
        [CustomExceptionFilter]
        public async Task<IActionResult> AddDeliveryToOrder(Guid id, Delivery delivery)
        {
            var findOrder = _context.Orders.Where(p => p.Id == id).FirstOrDefault();
            if (findOrder is null)
                return NotFound();

            findOrder.ShippingInfo.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(new { action = nameof(OrderController.GetOrderById), id = findOrder.Id }, findOrder);
        }

        [HttpPatch("{id}/shipments/{trackingNumber}")]
        [RestrictPatchOperationsAttribute<Shipment>]
        [CustomExceptionFilter]
        public async Task<IActionResult> UpdateShipmentInOrder(Guid id, string trackingNumber, JsonPatchDocument<Shipment> patch)
        {
            var findOrder = _context.Orders.Where(p => p.Id == id).FirstOrDefault();
            if (findOrder is null)
                return NotFound();

            var shipment = findOrder.ShippingInfo.Shipments.FirstOrDefault(sh => sh.TrackingNumber == trackingNumber);
            patch.ApplyTo(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}/deliveries")]
        [CustomExceptionFilter]
        public async Task<IActionResult> DeleteDeliveryFromOrder(Guid id, Delivery delivery)
        {
            var findOrder = _context.Orders.Where(p => p.Id == id).FirstOrDefault();
            if (findOrder is null)
                return NotFound();

            if (!findOrder.ShippingInfo.Deliveries.Any())
                return NotFound();

            var findDelivery = findOrder.ShippingInfo.Deliveries
                        .FirstOrDefault(d => d.ReceiverName == delivery.ReceiverName
                        && d.DeliveryDate == delivery.DeliveryDate
                        && d.Signature == delivery.Signature);
            if (findDelivery is null)
                return NotFound();

            findOrder.ShippingInfo.Deliveries.Remove(findDelivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            return Ok(order);
        }

        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetOrdersByCity(string city)
        {
            var orders = await _context.Orders.Where(o => o.ShippingInfo.City == city)
                                             .ToListAsync();

            return Ok(orders);
        }

        [HttpGet("shipmentDate/{shipmentDate}")]
        public async Task<IActionResult> GetOrdersByShipmentDate(DateTime shipmentDate)
        {
            var orders = await _context.Orders
                   .Select(o => new { order = o, shipments = o.ShippingInfo.Shipments })
                   .Where(o => o.shipments.Any(sh => sh.ShipDate.Date == shipmentDate.Date))
                   .Select(o => o.order)
                   .ToListAsync();

            return Ok(orders);
        }
    }
}
