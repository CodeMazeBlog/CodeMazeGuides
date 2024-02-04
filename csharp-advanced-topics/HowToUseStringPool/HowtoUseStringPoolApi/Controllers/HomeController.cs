using HowtoUseStringPoolApi.Model;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HowtoUseStringPoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController(IConfiguration configuration) : ControllerBase
    {
        private readonly StringPoolHelper _stringPoolHelper = new(configuration);

        [HttpGet]
        public string Init()
        {
            return _stringPoolHelper.Init();
        }

        [HttpPost("user")]
        public bool SaveUser([FromBody] UserModel user)
        {
            var success = _stringPoolHelper.AddUser(user.Name.AsSpan(), user.Email.AsSpan());

            return success;
        }

        [HttpGet("user/{name}")]
        public string GetUser(string name)
        {
            var email = _stringPoolHelper.GetUser(name.AsSpan());

            return email;
        }

        [HttpGet("log/{age}")]
        public int LogError(int age)
        {
            try
            {
                if (age <= 0 || age > 150)
                    throw new ArgumentException("Invalid Age");

                return age;
            }
            catch (ArgumentException ex)
            {
                _stringPoolHelper.LogError(ex.Message);
            }
            return -1;
        }

        [HttpGet("hostname")]
        public string GetHostName()
        {
            string url = Request.GetDisplayUrl();
            var hostName = _stringPoolHelper.GetHostName(url);

            return hostName;
        }

        [HttpGet("header/{key}")]
        public string GetHeader(string key)
        {
            var result = _stringPoolHelper.GetHeaderValue(Request, key.AsSpan());

            return result;
        }

        [HttpGet("checktoken")]
        public bool CheckToken()
        {
            return _stringPoolHelper.CheckToken(Request);
        }

        [HttpGet("encrypt/{text}")]
        public string EncryptText(string text)
        {
            return _stringPoolHelper.Encrypt(text);
        }

        [HttpGet("translate/{key}")]
        public string Translate(string key)
        {
            var langTurkish = "tr-TR".AsSpan();

            return _stringPoolHelper.Translate(key.AsSpan(), langTurkish);
        }

        [HttpGet("validate/{email}")]
        public bool IsValidEmail(string email)
        {
            return _stringPoolHelper.IsValidEmail(email);
        }

        [HttpPost("checkcontent")]
        public bool CheckContent(string content)
        {
            return _stringPoolHelper.CheckContent(content);
        }
    }
}
