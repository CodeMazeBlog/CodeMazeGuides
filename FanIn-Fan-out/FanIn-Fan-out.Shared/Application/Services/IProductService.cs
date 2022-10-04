using FanIn_Fan_out.Shared.Application.DataObjects;

namespace FanIn_Fan_out.Shared.Application.Services;

public interface IProductService
{
    Task<IEnumerable<int>> GetAllProductIds();

    Task<IEnumerable<SalesOrderDetailDTO>> GetSalesOrderDetailByProduct(int productId);

    IEnumerable<StatisticProductDTO> GetStatisticsProduct(IEnumerable<SalesOrderDetailDTO> salesOrderDetails);
}