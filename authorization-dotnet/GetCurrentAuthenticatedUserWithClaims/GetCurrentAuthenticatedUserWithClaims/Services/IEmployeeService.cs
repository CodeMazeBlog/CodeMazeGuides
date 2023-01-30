using GetCurrentAuthenticatedUserWithClaims.Models;

namespace GetCurrentUserWithClaims.Services
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployees();

    }
}
