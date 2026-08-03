using RateLimitingDemo.Common.Model;
using System;
using System.Collections.Generic;

namespace RateLimitingDemo.Common.Repositories;

public interface IProductCatalogRepository
{
    Product GetById(Guid id);
    List<Product> GetAll(); 
}
