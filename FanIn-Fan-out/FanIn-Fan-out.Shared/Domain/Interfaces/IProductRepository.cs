using FanIn_Fan_out.Shared.Domain.Models;

namespace FanIn_Fan_out.Shared.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<int>> GetAllProductIds();

    Task<IEnumerable<SalesOrderDetail>> GetSalesOrderDetailByProduct(int productId);
}