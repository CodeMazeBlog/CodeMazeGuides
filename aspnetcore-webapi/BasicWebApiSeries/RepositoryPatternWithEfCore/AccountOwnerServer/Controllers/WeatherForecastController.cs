using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public WeatherForecastController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // Proof that the wrapper resolves and both repositories reach the database.
        // Part 5 replaces this with a real OwnerController.
        [HttpGet]
        public IActionResult Get()
        {
            var domesticAccounts = _repository.Account
                .FindByCondition(a => a.AccountType == "Domestic")
                .Count();
            var owners = _repository.Owner.FindAll().Count();

            return Ok(new { owners, domesticAccounts });
        }
    }
}
