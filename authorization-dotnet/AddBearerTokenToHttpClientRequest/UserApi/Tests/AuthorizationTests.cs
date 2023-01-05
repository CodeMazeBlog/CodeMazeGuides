using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using UserApi.Controllers;
using UserApi.Database;
using UserApi.Models;

namespace UserApi.Tests
{
    public class AuthorizationTests
    {
        [Fact]
        public void GivenAnAuthenticateModelInstance_WhenUserIsInTheDatabase_ThenGenerateABearerToken()
        {
            var credentials = new AuthenticateModel()
            {
                Email = "JohnDoe@codemaze.com",
                Password = "123456"
            };

            var controller = CreateController();
            var result = controller.Login(credentials);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, ((ObjectResult)result).StatusCode);
            Assert.NotNull(((ObjectResult)result).Value);
        }

        [Fact]
        public void GivenAnAuthenticateModelInstance_WhenUserIsNotInTheDatabase_ThenReturnUnauthorized()
        {
            var credentials = new AuthenticateModel()
            {
                Email = "codemaze@codemaze.com",
                Password = "123456"
            };

            var controller = CreateController();
            var result = controller.Login(credentials);

            Assert.NotNull(result);
            Assert.IsType<UnauthorizedResult>(result);
            Assert.Equal(401, ((UnauthorizedResult)result).StatusCode);
        }

        [Fact]
        public void GivenANullAuthenticateModelInstance_WhenUserIsNull_ThenReturnBadRequest()
        {
            var controller = CreateController();
            var result = controller.Login(null);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, ((ObjectResult)result).StatusCode);
        }

        public AuthController CreateController()
        {
            return new AuthController(new UsersDatabase());
        }
    }
}