using Bogus;
using SingleAndSplitQueriesInEFCore.Model;

namespace SingleAndSplitQueriesInEFCore;

internal class DataGenerator
{
    public static List<Company> GenerateCompanies(int count)
    {
        var id = 0;

        var faker = new Faker<Company>()
            .CustomInstantiator(faker => new Company(++id, faker.Company.CompanyName()));

        return faker.Generate(count);
    }

    public static List<Product> GenerateProducts(List<Company> companies)
    {
        var id = 0;

        var faker = new Faker<Product>().CustomInstantiator(
            faker =>
            {
                var companyId = companies[id / 10].Id;
                return new Product(++id, faker.Commerce.ProductName(), companyId);
            });

        return faker.Generate(companies.Count * 10);
    }

    public static List<Department> GenerateDepartments(List<Company> companies)
    {
        var id = 0;

        var faker = new Faker<Department>().CustomInstantiator(
            faker =>
            {
                var companyId = companies[id / 10].Id;
                return new Department(++id, faker.Commerce.Department(), companyId);
            });

        return faker.Generate(companies.Count * 10);
    }
}
