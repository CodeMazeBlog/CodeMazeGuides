namespace SystemDynamicLinqCoreLibrary
{
    public class EmployeeData
    {
        public IQueryable<Employee> Employees;

        public EmployeeData()
        {
            GetEmployees();
        }

        public IQueryable<Employee> GetEmployees()
        {
            Employees = new[]
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
                        Name = "Test Company"
                    }
                }
            }.AsQueryable();

            return Employees;
        }
    }
}