using Microsoft.AspNetCore.Mvc;
using Order.Interfaces;
using Order.Models;
using Order.ViewModels;

namespace Order.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync(OrderViewModel viewModel)
    {
        try
        {
            await orderService.AddAsync(new OrderDto
            {
                Items = viewModel.Items.Select(i => new OrderItemDto
                {
                    ItemId = i.ItemId,
                    Quantity = i.Quantity
                }).ToList()
            });

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var orders = await orderService.GetAllAsync();

            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
