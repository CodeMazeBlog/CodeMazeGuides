using Business.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtistsApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistsController(MusicRepository musicRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Artist>> Get() => Ok(musicRepository.GetAllArtists());
}
