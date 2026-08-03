namespace TestDataGenerationWithAutoFixture
{
    public interface IPayrollService
    {
        void PaySalaries(IEnumerable<Employee> employee);
    }
}
