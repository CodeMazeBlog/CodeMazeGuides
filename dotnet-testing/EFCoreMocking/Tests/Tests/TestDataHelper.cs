namespace Tests
{
    public static class TestDataHelper
    {
        public static List<Employee> GetFakeEmployeeList()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "J.D@gmail.com",
                    Phone = "123-456-7890"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mark Luther",
                    Email = "M.L@gmail.com",
                    Phone = "123-456-7890"
                }
            };
        }
    }
}
