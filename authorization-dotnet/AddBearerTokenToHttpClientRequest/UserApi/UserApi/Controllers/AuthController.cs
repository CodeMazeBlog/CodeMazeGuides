using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserApi.Database;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersDatabase _usersDatabase;

        public AuthController(UsersDatabase usersDatabase)
        {
            _usersDatabase = usersDatabase;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest("Invalid client request.");
            }

            if (CheckRegisteredUser(loginModel))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new { token });
            }

            return Unauthorized();
        }

        private bool CheckRegisteredUser(AuthenticateModel loginModel)
        {
            return _usersDatabase.Any(x => x.Email.Equals(loginModel.Email, StringComparison.InvariantCultureIgnoreCase)
                            && x.Password == loginModel.Password);
        }
    }
}
