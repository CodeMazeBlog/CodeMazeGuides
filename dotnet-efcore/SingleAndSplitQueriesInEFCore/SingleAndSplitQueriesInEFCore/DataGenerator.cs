using Bogus;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

public class DataGenerator
{
    public static List<Company> GenerateCompanies(int count)
    {
        var id = 1;

        var faker = new Faker<Company>()
            .CustomInstantiator(faker => new Company(id++, faker.Company.CompanyName()));

        return faker.Generate(count);
    }

    public static List<Product> GenerateProducts(int count, List<Company> companies)
    {
        var id = 1;

        var faker = new Faker<Product>()
            .CustomInstantiator(faker => new Product(id++, faker.Commerce.ProductName(), faker.PickRandom(companies).Id));

        return faker.Generate(count);
    }

    public static List<Department> GenerateDepartments(int count, List<Company> companies)
    {
        var id = 1;

        var faker = new Faker<Department>()
            .CustomInstantiator(faker => new Department(id++, faker.Commerce.Department(), faker.PickRandom(companies).Id));

        return faker.Generate(count);
    }
}
