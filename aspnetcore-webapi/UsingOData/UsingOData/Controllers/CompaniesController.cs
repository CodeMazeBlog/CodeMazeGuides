using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace UsingOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepo _repo;
        public CompaniesController(ICompanyRepo repo)
        {
            _repo = repo;
        }

        [EnableQuery(PageSize = 3)]
        [HttpGet]
        public IQueryable<Company> Get()
        {
            return _repo.GetAll();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<Company> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_repo.GetById(key));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Create(company);

            return Created("companies", company);
        }

        [HttpPut]
        public IActionResult Put([FromODataUri] int key, [FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != company.ID)
            {
                return BadRequest();
            }

            _repo.Update(company);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            var company = _repo.GetById(key);
            if (company is null)
            {
                return BadRequest();
            }

            _repo.Delete(company.First());

            return NoContent();
        }

    }
}
