using FanIn_Fan_out.Shared.Application.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FanIn_Fan_out.Functions.Functions.Activities;

public class GetProductsActivity
{
    private readonly IProductService _productService;
    private readonly ILogger<GetProductsActivity> _logger;

    public GetProductsActivity(ILogger<GetProductsActivity> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [FunctionName("GetProductsIds")]
    public async Task<IEnumerable<int>> GetProductsIds([ActivityTrigger] string name)
    {
        _logger.LogInformation($"Executing GetProductsIds Activity");
        return await _productService.GetAllProductIds();
    }
}
