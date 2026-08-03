using EFCoreBestPractices.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ApplicationDbContext applicationDbContext) : ControllerBase
{
    [HttpGet("projection")]
    public async Task<ActionResult> GetProductDataUsingProjection()
    {
        var products = await applicationDbContext.Products
           .Select(p => new { p.Name, p.Id })
           .ToListAsync();

        return Ok(products);
    }

    [HttpGet("filter-early")]
    public async Task<ActionResult> GetProductDataByFilteringEarly()
    {
        var products = await applicationDbContext.Products
           .Where(p => p.Price > 10)
           .Select(x => new { x.Name, x.Price })
           .ToListAsync();

        return Ok(products);
    }

    [HttpPost("batch")]
    public async Task<ActionResult> PostProductDataUsingBatch()
    {
        var newProducts = new List<Product>
            {
                new Product { Name = "Product3", Price = 20 },
                new Product { Name = "Product4", Price = 30 },
            };

        applicationDbContext.Products.AddRange(newProducts);
        await applicationDbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("as-no-tracking")]
    public async Task<ActionResult> GetProductDataUsingAsNoTracking(int productId)
    {
        var product = await applicationDbContext.Products
           .Where(p => p.Id == productId)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        return Ok(product);
    }

    [HttpGet("skip-take")]
    public async Task<ActionResult> GetProductDataUsingSkipTake()
    {
        var pageNumber = 1;
        var pageSize = 10;

        var pagedProducts = await applicationDbContext.Products
           .OrderBy(p => p.Name)
           .Skip((pageNumber - 1) * pageSize)
           .Take(pageSize)
           .ToListAsync();

        return Ok(pagedProducts);
    }

    [HttpGet("eager-loading")]
    public async Task<ActionResult> GetCategoriesUsingEagerLoading()
    {
        var categoriesWithProducts = await applicationDbContext.Suppliers
           .Include(c => c.Orders)
           .Select(x => new
           {
               x.Name,
               Products = x.Orders!.Select(p => new
               {
                   p.ProductName,
               })
           })
           .ToListAsync();

        return Ok(categoriesWithProducts);
    }

    [HttpGet("split-queries")]
    public async Task<ActionResult> GetSupplierNamesUsingSplitQuery()
    {
        var suppliers = await applicationDbContext.Suppliers
           .Include(s => s.Orders)
           .AsSplitQuery()
           .Select(x => new
           {
               x.Name
           })
           .ToListAsync();

        return Ok(suppliers);
    }

    [HttpGet("compiled-query")]
    public ActionResult GetProductDataUsingCompiledQuery()
    {
        var expensiveProducts = CompiledQueries.GetExpensiveProducts(applicationDbContext, 30).ToList();

        return Ok(expensiveProducts);
    }

    [HttpPost("async-calls")]
    public async Task<ActionResult> PostProductDataUsingAsyncCalls()
    {
        var newProducts = new List<Product>
            {
                new Product { Name = "Product5", Price = 20 },
                new Product { Name = "Product6", Price = 30 },
            };

        await applicationDbContext.Products.AddRangeAsync(newProducts);
        await applicationDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("sql-injection")]
    public async Task<ActionResult> GetProductsDataByPreventingSqlInjection(int productId, string searchTerm)
    {
        // Validate user input
        if (productId <= 0 || string.IsNullOrWhiteSpace(searchTerm))
        {
            throw new ArgumentException("Invalid input parameters.");
        }

        // Use LINQ to construct a safe query with parameterized input
        var products = await applicationDbContext.Products
                          .Where(p => p.Id == productId && p.Name!.Contains(searchTerm))
                          .ToListAsync();

        return Ok(products);
    }
}