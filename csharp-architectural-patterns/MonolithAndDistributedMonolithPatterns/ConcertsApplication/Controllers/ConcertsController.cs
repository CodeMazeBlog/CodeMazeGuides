using Business.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace ConcertsApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class ConcertsController(MusicRepository musicRepository) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Concert> Get() => musicRepository.GetAllConcerts();
}
