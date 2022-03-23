using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PasswordlessAuthentication.Models;
using Microsoft.AspNetCore.Authentication;

namespace PasswordlessAuthentication.Controllers;

[Route("[controller]")]
public class LoginRedirectController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _iconfiguration;

    public LoginRedirectController(UserManager<IdentityUser> userManager, IConfiguration iconfiguration)
    {
        this._userManager = userManager;
        this._iconfiguration = iconfiguration;
    }


    [HttpGet]
    public async Task<IActionResult> Login(string Token, string Email, string ReturnUrl)
    {
        var user = await _userManager.FindByEmailAsync(Email);
        var isValid = await _userManager.VerifyUserTokenAsync(user, "Default", "passwordless-auth", Token);

        if (isValid)
        {
            await _userManager.UpdateSecurityStampAsync(user);

            await HttpContext.SignInAsync(
                IdentityConstants.ApplicationScheme,
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new List<Claim>
                        {
                            new Claim("sub", user.Id)
                        },
                        IdentityConstants.ApplicationScheme
                    )
                )
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwToken = tokenHandler.CreateToken(tokenDescriptor);

            if(ReturnUrl is null)
            {
                return Ok(new Tokens 
                { 
                    Token = tokenHandler.WriteToken(jwToken) 
                });
            }

            return new RedirectResult($"~{ReturnUrl}");
        }

        return Unauthorized();
    }
}
