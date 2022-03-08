using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PasswordlessAuthentication.Models;
using Microsoft.Extensions.Configuration;

namespace PasswordlessAuthentication.Controllers
{
    [Route("[controller]")]
    public class LoginRedirectController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration iconfiguration;

        public LoginRedirectController(UserManager<IdentityUser> userManager, IConfiguration iconfiguration)
        {
            this.userManager = userManager;
            this.iconfiguration = iconfiguration;
        }


        [HttpGet]
        public async Task<IActionResult> Login(string token, string email, string returnUrl)
        {
            var user = await userManager.FindByEmailAsync(email);
            var isValid = await userManager.VerifyUserTokenAsync(user, "Default", "passwordless-auth", token);

            if (isValid)
            {
                await userManager.UpdateSecurityStampAsync(user);

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
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                    new Claim(ClaimTypes.Email, email)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var jwToken = tokenHandler.CreateToken(tokenDescriptor);

                if(returnUrl == null)
                {
                    return new OkObjectResult(new Tokens { Token = tokenHandler.WriteToken(jwToken) });
                }

                return new RedirectResult($"~{returnUrl}");
            }

            return Unauthorized();
        }
    }
}
