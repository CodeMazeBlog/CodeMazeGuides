using DynamicFormInASPNetCore.Data;
using DynamicFormInASPNetCore.Models;
using DynamicFormInASPNetCore.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tests;

public class ProductTest
{
    private readonly IConfiguration _configuration;

    public ProductTest()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    [Fact]
    public void WhenPageLoad_OnGet_ReturnsAllProducts()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        try
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new DataContext(options);
            context.Database.EnsureCreated();

            var mockProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Pen", Price = 7.8m },
                new Product { Id = 2, Name = "Chips", Price = 1.5m }
            };

            context.Products.AddRange(mockProducts);
            context.SaveChanges();

            var productsModel = new IndexModel(context, _configuration);

            productsModel.OnGet();

            Assert.NotNull(productsModel.Products);

            Assert.Equal(mockProducts.Count, productsModel.Products.Count);
        }
        finally
        {
            connection.Close();
        }
    }

    [Fact]
    public void WhenAddingProduct_OnPostAddRow_ValidModel_AddsProduct()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        try
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new DataContext(options);
            context.Database.EnsureCreated();

            var productsModel = new IndexModel(context, _configuration)
            {
                Product = new Product { Name = "Ribbons", Price = 9.99m }
            };

            var actual = productsModel.OnPostAddRow();

            Assert.IsType<RedirectToPageResult>(actual);

            Assert.NotNull(context.Products.SingleOrDefault(p => p.Name == "Ribbons"));
        }
        finally
        {
            connection.Close();
        }
    }

    [Fact]
    public void WhenRemovingProduct_OnPostRemoveRow_RemovesProduct()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        try
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new DataContext(options);
            context.Database.EnsureCreated();

            var mockProduct = new List<Product>
            {
                new Product { Id = 1, Name = "Pen", Price = 7.8m }
            };

            context.Products.AddRange(mockProduct);
            context.SaveChanges();

            var productsModel = new IndexModel(context, _configuration);

            var actual = productsModel.OnPostRemoveRow(1);

            Assert.IsType<RedirectToPageResult>(actual);

            Assert.Null(context.Products.SingleOrDefault(p => p.Id == 1));
        }
        finally
        {
            connection.Close();
        }
    }
}