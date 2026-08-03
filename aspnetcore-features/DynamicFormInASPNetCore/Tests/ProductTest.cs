using DynamicFormInASPNetCore.Data;
using DynamicFormInASPNetCore.Models;
using DynamicFormInASPNetCore.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class ProductTest : IDisposable
{
    private readonly DataContext _context;

    public ProductTest()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite(connection)
            .Options;

        _context = new DataContext(options);
        _context.Database.EnsureCreated();

        var mockProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Pen", Price = 7.8m },
            new Product { Id = 2, Name = "Chips", Price = 1.5m }
        };

        _context.Products.AddRange(mockProducts);
        _context.SaveChanges();
    }

    [Fact]
    public void WhenPageLoadWithOnGet_ThenReturnsAllProducts()
    {
        var productsModel = new IndexModel(_context);
        productsModel.OnGet();

        Assert.NotNull(productsModel.Products);

        Assert.Equal(_context.Products.Count(), productsModel.Products.Count);
    }

    [Fact]
    public void WhenAddingProductWithOnPostAddRow_ThenAddsProduct()
    {
        var productsModel = new IndexModel(_context)
        {
            Product = new Product { Name = "Ribbons", Price = 9.99m }
        };

        var actual = productsModel.OnPostAddRow();

        Assert.IsType<RedirectToPageResult>(actual);

        Assert.NotNull(_context.Products.SingleOrDefault(p => p.Name == "Ribbons"));
    }

    [Fact]
    public void WhenRemovingProductWithOnPostRemoveRow_ThenRemovesProduct()
    {
        var productsModel = new IndexModel(_context);

        var actual = productsModel.OnPostRemoveRow(1);

        Assert.IsType<RedirectToPageResult>(actual);

        Assert.Null(_context.Products.SingleOrDefault(p => p.Id == 1));
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
