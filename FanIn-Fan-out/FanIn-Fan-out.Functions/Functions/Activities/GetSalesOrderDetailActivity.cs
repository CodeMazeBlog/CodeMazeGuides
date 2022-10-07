using FanIn_Fan_out.Shared.Application.DataObjects;
using FanIn_Fan_out.Shared.Application.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanIn_Fan_out.Functions.Functions.Activities;

public class GetSalesOrderDetailActivity
{
    private readonly IProductService _productService;
    private readonly ILogger<GetSalesOrderDetailActivity> _logger;

    public GetSalesOrderDetailActivity(ILogger<GetSalesOrderDetailActivity> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [FunctionName("GetSalesOrderDetails")]
    public async Task<IEnumerable<SalesOrderDetailDTO>> GetSalesOrderDetails([ActivityTrigger] int productId)
    {
        this._logger.LogInformation($"Executing GetSalesOrderDetails Activity - Get Sale details for productId={productId}");
        
        if(productId > 0)
        {
            return await this._productService.GetSalesOrderDetailByProduct(productId);
        }
        return Enumerable.Empty<SalesOrderDetailDTO>();
    }
}
