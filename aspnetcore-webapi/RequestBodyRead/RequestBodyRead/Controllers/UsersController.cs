using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RequestBodyRead.ModelBinders;
using RequestBodyRead.Service.Contracts;
using RequestBodyRead.Shared.DataTransferObjects;


namespace RequestBodyRead.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    private readonly IBufferService _bufferService;

    public UsersController(IUserService userService, IBufferService bufferService)
    {
        _userService = userService;
        _bufferService = bufferService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetUsers()
    {
        var users = _userService.GetUsers();

        return Ok(users);
    }

    [HttpGet("{id:guid}", Name = "UserById")]
    public ActionResult<UserDto> GetUser(Guid id)
    {
        var user = _userService.GetUser(id);

        return Ok(user);
    }

    [HttpGet("collection/({ids})", Name = "UserCollection")]
    public IActionResult GetUserCollection([FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var users = _userService.GetByIds(ids);

        return Ok(users);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserForCreationAndUpdateDto user)
    {
        if (user is null)
            return BadRequest("UserForCreationDto object is null");

        var createdUser = _userService.CreateUser(user);

        return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateUsers(bool buffer=false)
    {
        List<UserForCreationAndUpdateDto>? users;

        if (buffer)
        {
            users = await _bufferService.ReadUserModelAsync(this.Request.BodyReader);
        }
        else
        {
            string body = await new StreamReader(this.Request.Body).ReadToEndAsync();
            users = JsonConvert.DeserializeObject<List<UserForCreationAndUpdateDto>>(body);
        }

        var result = _userService.CreateUserCollection(users);
        return CreatedAtRoute("UserCollection", new { result.ids}, result.users);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UserForCreationAndUpdateDto user)
    {
        if (user is null)
            return BadRequest("UserDto object is null");

        var newOrUpdatedUser = _userService.UpdateUser(id, user);

        return NoContent();
    }
}

