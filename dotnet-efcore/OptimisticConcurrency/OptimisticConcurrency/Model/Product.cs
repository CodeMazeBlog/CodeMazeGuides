﻿namespace OptimisticConcurrency.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid Version { get; set; }
}