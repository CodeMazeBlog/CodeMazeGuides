using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ApplicationDbContext applicationDbContext) : ControllerBase
    {
        private readonly ApplicationDbContext _context = applicationDbContext;

        [HttpGet("projection")]
        public async Task<ActionResult> GetProductDataUsingProjection()
        {
            var products = await _context.Products
                                        .Where(p => p.Price > 10)
                                        .Select(p => new { p.Name, p.Id })
                                        .ToListAsync();

            return Ok(products);
        }

        [HttpGet("filter-early")]
        public async Task<ActionResult> GetProductDataByFilteringEarly()
        {
            var products = await _context.Products
                                        .Where(p => p.Price > 10)
                                        .Select(x => new { x.Name, x.Price})
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

            _context.Products.AddRange(newProducts); 
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("as-no-tracking")]
        public async Task<ActionResult> GetProductDataUsingAsNoTracking(int productId)
        {
            var product = await _context.Products
                                    .Where(p => p.Id == productId)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return Ok(product);
        }

        [HttpGet("skip-take")]
        public async Task<ActionResult> GetProductDataUsingSkipTake()
        {
            int pageNumber = 1; 
            int pageSize = 10; 

            var pagedProducts = await _context.Products
                                        .OrderBy(p => p.Name)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return Ok(pagedProducts);
        }

        [HttpGet("eager-loading")]
        public async Task<ActionResult> GetCategoriesUsingEagerLoading()
        {
            var categoriesWithProducts = await _context.Suppliers
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

        [HttpGet("compiled-query")]
        public ActionResult GetProductDataUsingCompiledQuery()
        {
            var expensiveProducts = CompiledQueries.GetExpensiveProducts(_context, 30).ToList();

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

            await _context.Products.AddRangeAsync(newProducts);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("sql-injection")]
        public async Task<ActionResult> GetProductsDataByPreventingSqlInjection(int producId, string searchTerm)
        {
            // Validate user input
            if (producId <= 0 || string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ArgumentException("Invalid input parameters.");
            }

            // Use LINQ to construct a safe query with parameterized input
            var products =  await _context.Products
                              .Where(p => p.Id == producId && p.Name!.Contains(searchTerm))
                              .ToListAsync();

            return Ok(products);
        }
    }
}