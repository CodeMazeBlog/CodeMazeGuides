using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingGenericList.Benchmarks;
internal static class BenchmarkSetupHelpers
{
    public static Product[] GenerateProducts(int count)
    {
        var faker = new AutoFaker<Product>()
                    .Configure(builder =>
                        builder.WithFakerHub(new Faker {Random = new Randomizer(42)}))
                    .RuleFor(p => p.ProductName, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Product()}")
                    .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1, 200)))
                    .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0]);

        return faker.Generate(count).ToArray();
    }
}
