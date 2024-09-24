using EFCoreBestPractices.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBestPractices;
public static class CompiledQueries
{
    public static readonly Func<ApplicationDbContext, decimal, IEnumerable<Product>> GetExpensiveProducts
        = EF.CompileQuery((ApplicationDbContext context, decimal price) =>
            context.Products.Where(p => p.Price > price));
}