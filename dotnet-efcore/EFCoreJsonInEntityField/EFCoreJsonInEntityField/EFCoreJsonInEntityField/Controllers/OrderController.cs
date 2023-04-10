using EFCoreJsonInEntityField.Filters;
using EFCoreJsonInEntityField.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreJsonInEntityField.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderContext context;

        public OrderController(OrderContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [CustomExceptionFilter]
        public async Task<IActionResult> AddOrder(Order order)
        {
            order.Id = Guid.NewGuid();
            order.OrderDate = DateTime.Now;
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        [RestrictPatchOperationsAttribute<Order>]
        [CustomExceptionFilter]
        public async Task<IActionResult> UpdateOrder(Guid id, JsonPatchDocument<Order> patch)
        {
            var findOrder = context.Orders.Where(p => p.Id == id).FirstOrDefault();
            patch.ApplyTo(findOrder);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id}/shipments")]
        [CustomExceptionFilter]
        public async Task<IActionResult> AddShipmentToOrder(Guid id, Shipment shipment)
        {
            var findOrder = context.Orders.Where(p => p.Id == id).FirstOrDefault();
            findOrder.ShippingInfo.Shipments.Add(shipment);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id}/deliveries")]
        public async Task<IActionResult> AddDeliveryToOrder(Guid id, Delivery delivery)
        {
            var findOrder = context.Orders.Where(p => p.Id == id).FirstOrDefault();
            findOrder.ShippingInfo.Deliveries.Add(delivery);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}/shipments/{trackingNumber}")]
        [RestrictPatchOperationsAttribute<Shipment>]
        [CustomExceptionFilter]
        public async Task<IActionResult> UpdateShipmentInOrder(Guid id, string trackingNumber, JsonPatchDocument<Shipment> patch)
        {
            var findOrder = context.Orders.Where(p => p.Id == id).FirstOrDefault();
            var shipment = findOrder.ShippingInfo.Shipments.FirstOrDefault(sh => sh.TrackingNumber == trackingNumber);
            patch.ApplyTo(shipment);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}/deliveries")]
        [CustomExceptionFilter]
        public async Task<IActionResult> DeleteDeliveryFromOrder(Guid id, Delivery delivery)
        {
            var findOrder = context.Orders.Where(p => p.Id == id).FirstOrDefault();
            if (findOrder == null)
                return NotFound();
            if (!findOrder.ShippingInfo.Deliveries.Any())
                return NotFound();
            var findDelivery = findOrder.ShippingInfo.Deliveries
                        .FirstOrDefault(d => d.ReceiverName == delivery.ReceiverName
                        && d.DeliveryDate == delivery.DeliveryDate
                        && d.Signature == delivery.Signature);
            if (findDelivery == null)
                return NotFound();
            findOrder.ShippingInfo.Deliveries.Remove(findDelivery);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await context.Orders.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            return Ok(order);
        }

        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetOrdersByCity(string city)
        {
            var orders = await context.Orders.Where(o => o.ShippingInfo.City == city)
                                             .ToListAsync();

            return Ok(orders);
        }

        [HttpGet("shipmentDate/{shipmentDate}")]
        public async Task<IActionResult> GetOrdersByShipmentDate(DateTime shipmentDate)
        {
            var orders = await context.Orders
                   .Select(o => new { order = o, shipments = o.ShippingInfo.Shipments })
                   .Where(o => o.shipments.Any(sh => sh.ShipDate.Date == shipmentDate.Date))
                   .Select(o => o.order)
                   .ToListAsync();

            return Ok(orders);
        }
    }
}
