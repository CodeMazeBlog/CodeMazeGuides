using InMemoryCacheExample.Models.Repository;

namespace InMemoryCacheExample.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeManager(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext ?? throw new ArgumentNullException(nameof(employeeContext));
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }
    }
}
