using System.Collections.ObjectModel;

namespace TemplateMethodPattern;

public class ProductService
{
    public static ReadOnlyCollection<Product> GetProducts()
    {
        return new (
        [
            new ("C", 30),
            new ("A", 20),
            new ("B", 15)
        ]);  
    }
}