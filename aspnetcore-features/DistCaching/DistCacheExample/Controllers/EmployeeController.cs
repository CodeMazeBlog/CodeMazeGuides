using DistCacheExample.Models.Repository;
using DistCacheExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using Microsoft.Extensions.Caching.Distributed;

namespace DistCacheExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private const string employeeListCacheKey = "employeeList";

        private readonly IDataRepository<Employee> _dataRepository;
        private readonly IDistributedCache _cache;
        private readonly ILogger<EmployeeController> _logger;
        private static readonly SemaphoreSlim semaphore = new(1, 1);

        public EmployeeController(IDataRepository<Employee> dataRepository,
            IDistributedCache cache,
            ILogger<EmployeeController> logger)
        {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            _logger.Log(LogLevel.Information, "Trying to fetch the list of employees from cache.");

            if (_cache.TryGetValue(employeeListCacheKey, out IEnumerable<Employee>? employees))
            {
                _logger.Log(LogLevel.Information, "Employee list found in cache.");
            }
            else
            {
                try
                {
                    await semaphore.WaitAsync();

                    if (_cache.TryGetValue(employeeListCacheKey, out employees))
                    {
                        _logger.Log(LogLevel.Information, "Employee list found in cache.");
                    }
                    else
                    {
                        _logger.Log(LogLevel.Information, "Employee list not found in cache. Fetching from database.");

                        employees = _dataRepository.GetAll();

                        var cacheEntryOptions = new DistributedCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                                .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600));

                        await _cache.SetAsync(employeeListCacheKey, employees, cacheEntryOptions);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _dataRepository.Add(employee);

            _cache.Remove(employeeListCacheKey);

            return new ObjectResult(employee) { StatusCode = (int)HttpStatusCode.Created };
        }
    }
}
