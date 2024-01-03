using Business.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Monolith.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistsController(MusicRepository musicRepository) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Artist> Get() => musicRepository.GetAllArtists();
}
