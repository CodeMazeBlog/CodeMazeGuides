using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace UsingOData
{
    public class CompanyRepo : ICompanyRepo
    {
        List<Company> companies;

        public CompanyRepo()
        {
            companies = new List<Company>()
            {
                new Company()
                {
                    ID = 1,
                    Name = "Company A",
                    Size = 25,
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ID = 1,
                            Name = "Product A",
                            Price = 10
                        },
                        new Product()
                        {
                            ID = 2,
                            Name = "Product B",
                            Price = 35
                        }
                    }
                },
                new Company()
                {
                    ID = 2,
                    Name = "Company B",
                    Size = 56,
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ID = 3,
                            Name = "Product C",
                            Price = 22
                        },
                        new Product()
                        {
                            ID = 4,
                            Name = "Product D",
                            Price = 15
                        }
                    }
                },
                new Company()
                {
                    ID = 3,
                    Name = "Company C",
                    Size = 12,
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ID = 5,
                            Name = "Product E",
                            Price = 103
                        },
                        new Product()
                        {
                            ID = 6,
                            Name = "Product F",
                            Price = 135
                        }
                    }
                },
                new Company()
                {
                    ID = 4,
                    Name = "Company D",
                    Size = 205,
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            ID = 7,
                            Name = "Product G",
                            Price = 76
                        },
                        new Product()
                        {
                            ID = 8,
                            Name = "Product H",
                            Price = 33
                        }
                    }
                },
            };
        }

        public IQueryable<Company> GetAll()
        {
            return companies.AsQueryable();
        }

        public IQueryable<Company> GetById(int id)
        {
            return companies
                .AsQueryable()
                .Where(c => c.ID == id);
        }
    }
}
