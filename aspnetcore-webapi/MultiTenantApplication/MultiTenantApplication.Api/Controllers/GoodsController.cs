namespace MultiTenantApplication.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class GoodsController : ControllerBase
{
    private readonly IGoodsRepository _goodsRepository;

    public GoodsController(IGoodsRepository goodsRepository)
    {
        _goodsRepository = goodsRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(GoodsDto goodsDto)
    {
        var goods = await _goodsRepository.AddAsync(goodsDto);

        return Created(string.Empty, goods);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync()
    {
        var list = await _goodsRepository.GetAllAsync();

        return Ok(list);
    }
}