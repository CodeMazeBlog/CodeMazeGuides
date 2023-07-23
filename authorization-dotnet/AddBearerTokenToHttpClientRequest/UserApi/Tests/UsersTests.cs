using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Controllers;
using UserApi.Database;
using UserApi.Models;

namespace UserApi.Tests
{
    public class UsersTests
    {
        [Fact]
        public void GivenAGeUsersMethod_WhenTheDatabaseIsNotNull_ThenReturnAListWithEveryUser()
        {
            var controller = CreateController();
            var result = controller.GetUsers();

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, ((ObjectResult)result).StatusCode);
            Assert.NotNull(((ObjectResult)result).Value);
        }

        [Fact]
        public void GivenASpecificId_WhenTheIdIsInTheDatabase_ThenReturnThisSpecificUser()
        {
            var specificId = 1;

            var controller = CreateController();
            var result = controller.GetUserById(specificId);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, ((ObjectResult)result).StatusCode);
            Assert.NotNull(((ObjectResult)result).Value);
        }

        [Fact]
        public void GivenASpecificId_WhenTheIdIsNotInTheDatabase_ThenReturnBadRequest()
        {
            var specificId = 99;

            var controller = CreateController();
            var result = controller.GetUserById(specificId);

            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, ((NotFoundResult)result).StatusCode);
        }

        [Fact]
        public void GivenAUserModelInstance_WhenInsertingIntoTheDatabase_ThenReturnCreated()
        {
            var userModel = new UserModel
            {
                Email = "code@maze.com",
                FirstName = "Code",
                LastName = "Maze",
                Password = "789456123"
            };

            var controller = CreateController();
            var result = controller.CreateUser(userModel);

            Assert.NotNull(result);
            Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, ((ObjectResult)result).StatusCode);
        }

        private UsersController CreateController()
        {
            return new UsersController(new UsersDatabase());
        }
    }
}
