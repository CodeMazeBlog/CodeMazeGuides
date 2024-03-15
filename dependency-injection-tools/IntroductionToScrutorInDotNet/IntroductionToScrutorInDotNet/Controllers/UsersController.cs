using IntroductionToScrutorInDotNet.Entities;
using IntroductionToScrutorInDotNet.Repositories;
using IntroductionToScrutorInDotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToScrutorInDotNet.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IRepository<User> _userRepository;

    public UsersController(IUserService userService, IRepository<User> userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userRepository.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUser(int id)
    {
        return Ok(_userService.GetUser(id));
    }
}