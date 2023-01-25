using GetCurrentAuthenticatedUserWithClaims.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GetCurrentAuthenticatedUserWithClaims.Services
{
    public class EmployeeService 
    { 
        private readonly ApplicationContext _context; 
        private readonly IHttpContextAccessor _httpContextAccessor; 
        public EmployeeService(ApplicationContext context, IHttpContextAccessor httpContextAccessor) 
        { 
            _context = context; 
            _httpContextAccessor = httpContextAccessor; 
        } 
        
        public async Task<List<Employee>> GetAllEmployees() 
        { 
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name); 
            
            return await _context.Employees.ToListAsync(); 
        } 
    }
}
