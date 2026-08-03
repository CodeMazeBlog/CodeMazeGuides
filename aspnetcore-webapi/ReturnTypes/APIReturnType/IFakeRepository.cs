namespace APIReturnType
{
    public interface IFakeRepository
    {
        public IEnumerable<Employee> GetEmployees();

        public bool TryGetEmployee(int id, out Employee? employee);

        public IEnumerable<Employee> GetActiveEmployees();

        public IAsyncEnumerable<Employee> GetActiveEmployeesAsync();

        public Task AddEmployeeAsync(Employee? employee);
    }
}