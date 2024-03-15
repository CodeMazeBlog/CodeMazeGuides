using AutoMapper;
using CodeMazeShop.DataContracts.Ordering;
using CodeMazeShop.Services.Ordering.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeShop.Services.Ordering.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderController(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersForUser([FromQuery] string userId) 
        => Ok(_mapper.Map<List<Order>>(await _orderRepository.GetOrdersForUser(userId)));
    
}