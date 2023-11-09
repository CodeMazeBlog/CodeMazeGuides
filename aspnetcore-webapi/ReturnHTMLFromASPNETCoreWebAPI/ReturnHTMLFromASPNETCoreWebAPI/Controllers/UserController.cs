using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReturnHTMLFromASPNETCoreWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            var html = "<p>Welcome to Code Maze</p>";

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        [HttpGet("verify")]
        public ContentResult Verify()
        {
            var html = "<div>Your account has been verified.</div>";

            return base.Content(html, "text/html");
        }

        [HttpGet("confirm-verify")]
        public ContentResult ConfirmVerify()
        {
            var html = System.IO.File.ReadAllText(@"./assets/verified.html");

            return base.Content(html, "text/html");
        }

        [HttpGet("welcome")]
        public ContentResult Welcome(string name)
        {
            var html = WelcomeHTML(name);

            return base.Content(html, "text/html");
        }

        protected string WelcomeHTML(string name)
        {
            var html = System.IO.File.ReadAllText(@"./assets/welcome.html");

            html = html.Replace("{{name}}", name);

            return html;
        }
    }
}
