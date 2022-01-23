using RateLimitingDemo.Common.Model;
using System;
using System.Collections.Generic;

namespace  RateLimitingDemo.Common.Repositories;

public interface IProductCatalogRepository
{
    void Create(Product product);
    Product GetById(Guid id);
    List<Product> GetAll();
    void Update(Product product);
    void Delete(Guid id);
}

