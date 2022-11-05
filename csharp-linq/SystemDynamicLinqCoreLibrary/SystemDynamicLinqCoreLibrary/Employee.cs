namespace SystemDynamicLinqCoreLibrary;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Age { get; set; }
    public string Residence { get; set; }
    public Employer Employer { get; set; }

    public IQueryable<Employee> GetEmployees()
    {
        return new[]
        {
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Department = "IT",
                Age = 25,
                Residence = "Malibu"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                Department = "Finance",
                Age = 30,
                Residence = "Prague"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Quincy Nigellus",
                Department = "Finance",
                Age = 28,
                Residence = "Birmingham"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Sharron Zachary",
                Department = "IT",
                Age = 23,
                Residence = "London"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Kristia Cletis",
                Department = "Human Resource",
                Age = 26,
                Residence = "Melbourne"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Chrissie Elihu",
                Department = "Human Resource",
                Age = 27,
                Residence = "Dakar"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Businge Missy",
                Department = "Hospitality",
                Age = 29,
                Residence = "Kampala"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Bob Mkenya",
                Department = "Infrastructure",
                Age = 25,
                Residence = "Kenya",
                Employer = new Employer
                {
                    Id = 0,
                    Name = "Block 10"
                }
            }
        }.AsQueryable();
    }
}

public class Employer
{
    public long Id { get; set; }

    public string Name { get; set; }
}