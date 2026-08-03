using Microsoft.AspNetCore.Mvc;
using response_caching.Controllers;
using System.Net;
using Xunit;

namespace Tests
{
    public class ValuesControllerTest
    {
        [Fact]
        public void Get_WhenInvoked_ReturnSuccessStatusCode()
        {
            var controller = new ValuesController();
            var result = controller.Get();
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, ((ObjectResult)result).StatusCode);
        }
    }
}