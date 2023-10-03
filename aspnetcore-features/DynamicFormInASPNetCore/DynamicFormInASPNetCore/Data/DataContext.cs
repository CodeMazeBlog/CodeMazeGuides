using DynamicFormInASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormInASPNetCore.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}

