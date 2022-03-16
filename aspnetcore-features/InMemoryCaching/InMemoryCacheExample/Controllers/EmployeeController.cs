using InMemoryCacheExample.Models.Repository;
using InMemoryCacheExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCacheExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;
        private IMemoryCache _cache;
        private ILogger<EmployeeController> _logger;

        public EmployeeController(IDataRepository<Employee> dataRepository,
            IMemoryCache cache,
            ILogger<EmployeeController> logger)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            _logger.Log(LogLevel.Information, "Trying to fetch the list of employees from cache.");

            if (!_cache.TryGetValue("employeeList", out IEnumerable<Employee> employees))
            {
                _logger.Log(LogLevel.Information, "Employee list not found in cache. Fetching from database.");
                employees = _dataRepository.GetAll();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);

                _cache.Set("employeeList", employees, cacheEntryOptions);
            }
            else
            {
                _logger.Log(LogLevel.Information, "Employee list found in cache.");
            }

            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Employee employee = _dataRepository.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(employee);
        }
    }
}
