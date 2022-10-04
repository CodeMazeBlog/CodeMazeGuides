using AutoMapper;
using FanIn_Fan_out.Shared.Application.DataObjects;
using FanIn_Fan_out.Shared.Domain.Interfaces;
using FanIn_Fan_out.Shared.Domain.Models;

namespace FanIn_Fan_out.Shared.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<int>> GetAllProductIds() => await this._productRepository.GetAllProductIds();

    public async Task<IEnumerable<SalesOrderDetailDTO>> GetSalesOrderDetailByProduct(int productId)
    {
        IEnumerable<SalesOrderDetail> salesOrderDetails = await this._productRepository.GetSalesOrderDetailByProduct(productId);
        if(salesOrderDetails != null && salesOrderDetails.Any())
        {
            return _mapper.Map<IEnumerable<SalesOrderDetailDTO>>(salesOrderDetails);
        }
        return Enumerable.Empty<SalesOrderDetailDTO>();
    }

    public IEnumerable<StatisticProductDTO> GetStatisticsProduct(IEnumerable<SalesOrderDetailDTO> salesOrderDetails)
        => salesOrderDetails.GroupBy(s => s.ProductId).Select(s => new StatisticProductDTO { ProductId = s.Key, SaleQuantity = s.Sum(p => p.OrderQty), SaleTotalPrice = s.Sum(p => p.LineTotal) });
}