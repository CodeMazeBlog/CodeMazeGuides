using ClientServerArchitecture.Data;
using ClientServerArchitecture.Models;

namespace ClientServerArchitecture.Data_Access;

public class ProductRepository
{
    private readonly ProductDataContext _context;

    public ProductRepository(ProductDataContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
