namespace UsingOData
{
    public class DBSeeder
    {
        public static void AddCompaniesData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<ApiContext>();

            db.Companies.Add(
                new Company()
                {
                    ID = 1,
                    Name = "Company A",
                    Size = 25
                });

            db.Companies.Add(
                new Company()
                {
                    ID = 2,
                    Name = "Company B",
                    Size = 56
                });

            db.Companies.Add(
                new Company()
                {
                    ID = 3,
                    Name = "Company C",
                    Size = 12
                });

            db.Companies.Add(
                new Company()
                {
                    ID = 4,
                    Name = "Company D",
                    Size = 205
                });

            db.Products.Add(
                new Product()
                {
                    ID = 1,
                    CompanyID = 1,
                    Name = "Product A",
                    Price = 10
                });

            db.Products.Add(
                new Product()
                {
                    ID = 2,
                    CompanyID = 1,
                    Name = "Product B",
                    Price = 35
                });

            db.Products.Add(
                new Product()
                {
                    ID = 3,
                    CompanyID = 2,
                    Name = "Product C",
                    Price = 22
                });

            db.Products.Add(
                new Product()
                {
                    ID = 4,
                    CompanyID = 2,
                    Name = "Product D",
                    Price = 15
                });

            db.Products.Add(
                new Product()
                {
                    ID = 5,
                    CompanyID = 3,
                    Name = "Product E",
                    Price = 103
                });

            db.Products.Add(
                new Product()
                {
                    ID = 6,
                    CompanyID = 3,
                    Name = "Product F",
                    Price = 135
                });

            db.Products.Add(
                new Product()
                {
                    ID = 7,
                    CompanyID = 4,
                    Name = "Product G",
                    Price = 76
                });

            db.Products.Add(
                new Product()
                {
                    ID = 8,
                    CompanyID = 4,
                    Name = "Product H",
                    Price = 33
                });

            db.SaveChanges();
        }

    }
}


