using API.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("EnableCors")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly LanguageRepository _repo;

        public LanguagesController(LanguageRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("[action]")]
        public IActionResult GetLanguageStats()
        {
            var languageStats = _repo.GetLanguages().ToList();

            if (languageStats != null && languageStats.Count > 0)
                return Ok(languageStats);

            return BadRequest();
        }
    }
}
