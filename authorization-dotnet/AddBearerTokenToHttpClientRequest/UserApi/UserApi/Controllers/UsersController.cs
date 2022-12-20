using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Database;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersDatabase _usersDatabase;

        public UsersController(UsersDatabase usersDatabase)
        {
            _usersDatabase = usersDatabase;
        }

        [HttpPost, Authorize]
        public IActionResult CreateUser(UserModel userModel)
        {
            _usersDatabase.AddUser(userModel);

            return new ObjectResult(userModel)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpGet, Authorize]
        public IActionResult GetUsers()
        {
            return Ok(_usersDatabase);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetUserById(int id) 
        {
            var user = _usersDatabase.FirstOrDefault(x => x.Id == id);

            if(user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
