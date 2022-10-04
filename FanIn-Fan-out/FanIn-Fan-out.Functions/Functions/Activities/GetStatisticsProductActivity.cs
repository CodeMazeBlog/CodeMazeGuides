using FanIn_Fan_out.Shared.Application.DataObjects;
using FanIn_Fan_out.Shared.Application.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanIn_Fan_out.Functions.Functions.Activities;

public class GetStatisticsProductActivity
{
    private readonly IProductService _productService;
    private readonly ILogger<GetStatisticsProductActivity> _logger;

    public GetStatisticsProductActivity(ILogger<GetStatisticsProductActivity> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [FunctionName("GetStatisticsProduct")]
    public IEnumerable<StatisticProductDTO> GetProductsIds([ActivityTrigger] IEnumerable<SalesOrderDetailDTO> salesOrderDetails)
    {
        _logger.LogInformation($"Executing GetProductsIds Activity");
        if(salesOrderDetails != null && salesOrderDetails.Any())
        {
            return _productService.GetStatisticsProduct(salesOrderDetails);
        }
        return Enumerable.Empty<StatisticProductDTO>();
    }
}
