using BackgroundServiceExecuteAsyncAndStartAsync.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServiceExecuteAsyncAndStartAsync.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockPriceController(IStockPriceRepository stockPriceRepository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTodayStockPrices() => Ok(await stockPriceRepository.GetTodayStockPricesAsync());
}