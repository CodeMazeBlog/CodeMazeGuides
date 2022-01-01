using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsBadSolution
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

        public double Tax
        {
            get
            {
                if (ProductType == ProductType.Household)
                    return Price * 0.02;
                else if (ProductType == ProductType.Electronics)
                    return Price * 0.01;
                else if (ProductType == ProductType.Clothes)
                    return Price * 0.03;
                return 0;
            }
        }
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
            return products.Select(p => p.Price + p.Tax).Sum();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateTotalPrice(Products));
        }
    }
}
