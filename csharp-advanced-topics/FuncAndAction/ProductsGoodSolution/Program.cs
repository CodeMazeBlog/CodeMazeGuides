using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsGoodSolution
{

    public class Product
    {
        public Product(double price, ProductType productType)
        {
            Price = price;
            ProductType = productType;
        }

        public double Price { get; set; }
        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        Electronics,
        Household,
        Clothes
    }
    class Program
    {
        static List<Product> Products = new List<Product>()
        {
            new Product(100, ProductType.Clothes),
            new Product(100, ProductType.Electronics),
            new Product(100, ProductType.Household),
        };

        static double CalculateTotalPrice(List<Product> products)
        {
            return products.Select(p => p.Price + TaxManager.TaxCalculatorDict[p.ProductType](p.Price)).Sum();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateTotalPrice(Products));
        }
    }
}
