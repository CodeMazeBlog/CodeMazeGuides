using Microsoft.AspNetCore.Mvc;

namespace HowToUseMapster.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController: ControllerBase
    {
    [HttpGet("new-person")]
    public IActionResult GetNewPerson()
    {
      var person = MappingFunctions.MapPersonToNewDto();

      return Ok(person);
    }

    [HttpGet("existing-person")]
    public IActionResult GetExistingPerson()
    {
      var person = MappingFunctions.MapPersonToExistingDto();

      return Ok(person);
    }

    [HttpGet]
    public IActionResult GetPeopleQueryable()
    {
      var people = MappingFunctions.MapPersonQueryableToDtoQueryable();

      return Ok(people);
    }

    [HttpGet("short-person")]
    public IActionResult GetShortPerson()
    {
      var person = MappingFunctions.CustomMapPersonToShortInfoDto();

      return Ok(person);
    }

    [HttpGet("entity")]
    public IActionResult GetPersonEntity()
    {
      var person = MappingFunctions.MapPersonDtoToPersonEntity();

      return Ok(person);
    }
  }
}
