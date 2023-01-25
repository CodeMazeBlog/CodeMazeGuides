using GetCurrentAuthenticatedUserWithClaims.Models;
using GetCurrentAuthenticatedUserWithClaims.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace GetCurrentAuthenticatedUserWithClaims.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger,
            EmployeeService service, 
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Employees()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);
            var firstName = User.FindFirstValue("firstname");
            var lastName = User.FindFirstValue("lastname");

            var employees = await _service.GetAllEmployees();
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}