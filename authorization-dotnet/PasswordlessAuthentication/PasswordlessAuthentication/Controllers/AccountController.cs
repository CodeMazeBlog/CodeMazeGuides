using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PasswordlessAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordlessAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return Ok(new { 
                message = "Unrecognized user. You must sign in to use this weather service.",
                loginUrl = Url.ActionLink(action: "", controller: "Account", values: new {
                    returnURL = returnURL
                }, protocol: Request.Scheme),
                schema = "{ \n userName * string \n  email * string($email) \n }"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Login...
            var user = await userManager.FindByEmailAsync(model.Email);
            KeyValuePair<string, StringValues> returnUrl = new KeyValuePair<string, StringValues>("", "");
            if(HttpContext != null)
            {
                returnUrl = HttpContext.Request.Query.FirstOrDefault(r => r.Key == "returnUrl");
            }

            if(user == null)
            {
                // user doesn't exist, try to create a new account
                // user enumeration vulnerability?
                return Unauthorized();
            } else
            {
                // continue
                var token = userManager.GenerateUserTokenAsync(user, "Default", "passwordless-auth");
                var url = Url.ActionLink(action: "", controller: "LoginRedirect", values: new { 
                    token = token.Result,
                    email = model.Email,
                    returnUrl = returnUrl.Value
                }, protocol: Request.Scheme);
                return Ok(url);
            }
        }
    }
}
