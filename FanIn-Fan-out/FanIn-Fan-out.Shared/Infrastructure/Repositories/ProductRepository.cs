using FanIn_Fan_out.Shared.Domain.Interfaces;
using FanIn_Fan_out.Shared.Domain.Models;
using FanIn_Fan_out.Shared.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Lab_Fan_out_Fan_in_Fonctions_Durables​.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AdventureWorks2012Context _context;

    public ProductRepository(AdventureWorks2012Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<int>> GetAllProductIds()
    {
        var res = await _context.Product.Select(p => p.ProductId).ToListAsync();
        return res;
    }

    public async Task<IEnumerable<SalesOrderDetail>> GetSalesOrderDetailByProduct(int productId) => await this._context.SalesOrderDetail.Where(s => s.ProductId == productId).ToListAsync();
}