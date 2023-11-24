using AutoFacImplementationWeb.Interface;

using Microsoft.AspNetCore.Mvc;

namespace AutoFacImplementationWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringHelperController : ControllerBase
    {
        public IStringBusiness StringBusiness { get; set; }

        [HttpGet]
        [Route("getUpperCase/{fullName}")]
        public string GetUpperCase(string fullName)
        {
            var upper = StringBusiness.StringToUpper(fullName);
            return upper;
        }
    }
}
