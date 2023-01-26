using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.ComponentModel.DataAnnotations;
using TestingUserAndRoleManager.Controllers;
using TestingUserAndRoleManager.Models;

namespace TestingUserAndRoleManagerUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
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

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<User>(userRegistrationModel)).Returns(user);

            var controller = new AccountController(mapperMock.Object, userManagerMock.Object);
            var result = (RedirectToActionResult) await controller.Register(userRegistrationModel);

            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async void Test2()
        {
            var userRegistrationModel = new UserRegistrationModel()
            {
                FirstName = "Test1",
                LastName = "Test2",
                Email = null,
                Password = "Test4",
                ConfirmPassword = "Test4"
            };

            var user = new User()
            {
                UserName = "Test3",
                FirstName = "Test1",
                LastName = "Test2",
                Email = null
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

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<User>(userRegistrationModel)).Returns(user);

            var controller = new AccountController(mapperMock.Object, userManagerMock.Object);
            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(userRegistrationModel,new ValidationContext(userRegistrationModel), validationResultList);
            foreach (var valResult in validationResultList)
            {
                var name = valResult.MemberNames.First();
                controller.ModelState.AddModelError(name, valResult.ErrorMessage);
            }
            var result = (ViewResult)await controller.Register(userRegistrationModel);

            Assert.Null(result.ViewName);
        }

        [Fact]
        public async void Test3()
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
                    Code = "dummy text",
                    Description = "dummy text"
                }
            };
            userManagerMock
                .Setup(userManager => userManager.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed(identityErrors)));
            userManagerMock
                .Setup(userManager => userManager.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()));

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<User>(userRegistrationModel)).Returns(user);

            var controller = new AccountController(mapperMock.Object, userManagerMock.Object);
            var result = (ViewResult)await controller.Register(userRegistrationModel);

            Assert.Null(result.ViewName);
        }

    }
}