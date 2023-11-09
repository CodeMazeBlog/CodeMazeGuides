using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using TestingUserAndRoleManager.Controllers;
using TestingUserAndRoleManager.Models;

namespace TestingUserAndRoleManagerUnitTests
{
    public class TestingUserAndRoleManagerUnitTests
    {
        [Fact]
        public async void WhenCorrectDataProvided_ThenRegistrationSuccessful()
        {
            var userRegistrationModel = new UserRegistrationModel()
            {
                FirstName = "Test1",
                LastName = "Test2",
                Email = "Test3",
                Password = "Test4",
                ConfirmPassword = "Test4"
            };

            var user = new User()
            {
                UserName = "Test3",
                FirstName = "Test1",
                LastName = "Test2",
                Email = "Test3"
            };

            var userManagerMock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);

            userManagerMock
                .Setup(userManager => userManager.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));
            userManagerMock
                .Setup(userManager => userManager.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()));

            var list = new List<IdentityRole>()
            {
                new IdentityRole("Administrator"),
                new IdentityRole("Visitor")
            }
            .AsQueryable();

            var roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object,
                new IRoleValidator<IdentityRole>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object);

            roleManagerMock
                .Setup(r => r.Roles).Returns(list);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<User>(userRegistrationModel)).Returns(user);

            var controller = new AccountController(mapperMock.Object, userManagerMock.Object, roleManagerMock.Object);
            var result = (RedirectToActionResult) await controller.Register(userRegistrationModel);

            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async void WhenCreateUserFails_ThenRegistrationNotSuccessful()
        {
            var userRegistrationModel = new UserRegistrationModel()
            {
                FirstName = "Test1",
                LastName = "Test2",
                Email = "Test3",
                Password = "Test4",
                ConfirmPassword = "Test4"
            };

            var user = new User()
            {
                UserName = "Test3",
                FirstName = "Test1",
                LastName = "Test2",
                Email = "Test3"
            };

            var userManagerMock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);

            var identityErrors = new IdentityError[]
            {
                new IdentityError()
                {
                    Code = "Username already exists",
                    Description = "Username already exists"
                }
            };
            userManagerMock
                .Setup(userManager => userManager.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed(identityErrors)));
            userManagerMock
                .Setup(userManager => userManager.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()));

            var roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object,
                new IRoleValidator<IdentityRole>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object);

            var list = new List<IdentityRole>()
            {
                new IdentityRole("Administrator"),
                new IdentityRole("Visitor")
            }
            .AsQueryable();

            roleManagerMock
                .Setup(r => r.Roles).Returns(list);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<User>(userRegistrationModel)).Returns(user);

            var controller = new AccountController(mapperMock.Object, userManagerMock.Object, roleManagerMock.Object);
            var result = (ViewResult)await controller.Register(userRegistrationModel);

            Assert.Null(result.ViewName);
        }       
    }
}