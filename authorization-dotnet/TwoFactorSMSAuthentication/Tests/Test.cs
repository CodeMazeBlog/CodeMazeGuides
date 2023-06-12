using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using TwoFactorAuthentication.Areas.Identity.Services;
using TwoFactorSMSAuthentication.Areas.Identity.Data;
using TwoFactorSMSAuthentication.Areas.Identity.Pages.Account;

namespace Tests
{
    public class Test
    {
        private RegisterModel _registerModel;
        private LoginModel _loginModel;
        private LoginWith2faModel _loginWith2faModel;
        private Mock<SignInManager<AppUser>> _signInManager;
        private Mock<UserManager<AppUser>> _userManager;
        private Mock<IUserStore<AppUser>> _userStore;
        private Mock<IUserEmailStore<AppUser>> _emailStore;
        private Mock<ILogger<RegisterModel>> _registerLogger;
        private Mock<ILogger<LoginModel>> _loginLogger;
        private Mock<ILogger<LoginWith2faModel>> _login2faLogger;
        private Mock<IEmailSender> _emailSender;
        private Mock<ISmsSender> _smsSender;

        public Test()
        {
            _userStore = new Mock<IUserStore<AppUser>>();

            _userManager = new Mock<UserManager<AppUser>>(
                _userStore.Object, Mock.Of<IOptions<IdentityOptions>>(),
              Mock.Of<IPasswordHasher<AppUser>>(),
              new IUserValidator<AppUser>[0],
              new IPasswordValidator<AppUser>[0],
              Mock.Of<ILookupNormalizer>(),
              Mock.Of<IdentityErrorDescriber>(),
              Mock.Of<IServiceProvider>(),
              Mock.Of<ILogger<UserManager<AppUser>>>());

            _signInManager = new Mock<SignInManager<AppUser>>(
                _userManager.Object,
                 Mock.Of<IHttpContextAccessor>(),
                 Mock.Of<IUserClaimsPrincipalFactory<AppUser>>(),
                 Mock.Of<IOptions<IdentityOptions>>(),
                 Mock.Of<ILogger<SignInManager<AppUser>>>(),
                 Mock.Of<IAuthenticationSchemeProvider>(),
                 Mock.Of<IUserConfirmation<AppUser>>()
                );

            _registerLogger = new Mock<ILogger<RegisterModel>>();

            _loginLogger = new Mock<ILogger<LoginModel>>();

            _login2faLogger = new Mock<ILogger<LoginWith2faModel>>();

            _emailSender = new Mock<IEmailSender>();

            _smsSender = new Mock<ISmsSender>();

            _emailStore = new Mock<IUserEmailStore<AppUser>>();
        }

        [Fact]
        public async void OnRegisterPostAsync_WhenUserRegister_ThenReturnSuccess()
        {
            _registerModel = new RegisterModel(_userManager.Object, _userStore.Object, _signInManager.Object, _registerLogger.Object, _emailSender.Object)
            {
                Input = new RegisterModel.InputModel()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "test@test.com",
                    Password = "Password1!",
                    ConfirmPassword = "Password1!"
                },

                EmailStore = _emailStore.Object
            };

            _userManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));

            _signInManager.Setup(x => x.SignInAsync(It.IsAny<AppUser>(), false, null)).Returns(Task.FromResult(IdentityResult.Success));            

            var result = await _registerModel.OnPostAsync("~/");

            Assert.IsType<LocalRedirectResult>(result);

            var redirect = result as LocalRedirectResult;

            Assert.Equal("~/", redirect.Url);
        }

        [Fact]
        public async void OnLoginPostAsync_WhenUserLogin_ThenReturnSuccess()
        {

            _loginModel = new LoginModel(_signInManager.Object, _loginLogger.Object)
            {
                Input = new LoginModel.InputModel()
                {
                    Email = "test@test.com",
                    Password = "Password1!",
                    RememberMe = false
                }
            };

            _signInManager.Setup(x =>
                x.PasswordSignInAsync(It.IsAny<string>(),
                                      It.IsAny<string>(),
                                      It.IsAny<bool>(),
                                      It.IsAny<bool>()))
                .Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Success));

            var result = await _loginModel.OnPostAsync("~/");

            Assert.IsType<LocalRedirectResult>(result);

            var redirect = result as LocalRedirectResult;

            Assert.Equal("~/", redirect.Url);
        }

        [Fact]
        public async void OnLoginPostAsync_WhenUserLoginWithTwoFactorEnabled_ThenRedirectToLoginWith2FA()
        {
            _loginModel = new LoginModel(_signInManager.Object, _loginLogger.Object)
            {
                Input = new LoginModel.InputModel()
                {
                    Email = "test@test.com",
                    Password = "Password1!",
                    RememberMe = false
                }
            };

            _signInManager.Setup(x =>
                x.PasswordSignInAsync(It.IsAny<string>(),
                                      It.IsAny<string>(),
                                      It.IsAny<bool>(),
                                      It.IsAny<bool>()))
                .Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.TwoFactorRequired));

            var result = await _loginModel.OnPostAsync("~/");

            Assert.IsType<RedirectToPageResult>(result);

            var redirect = result as RedirectToPageResult;

            Assert.Equal("./LoginWith2fa", redirect.PageName);
        }

        [Fact]
        public async void OnLogin2faPostAsync_WhenProvideOTP_ThenReturnSuccess()
        {
            _loginWith2faModel = new LoginWith2faModel(_signInManager.Object, _userManager.Object, _login2faLogger.Object, _smsSender.Object)
            {
                Input = new LoginWith2faModel.InputModel()
                {
                    TwoFactorCode = "123456"
                }
            };

            _signInManager.Setup(x => x.GetTwoFactorAuthenticationUserAsync()).Returns(Task.FromResult(new AppUser()));

            _signInManager.Setup(x =>
                x.TwoFactorSignInAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>()))
                .Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Success));

            var result = await _loginWith2faModel.OnPostAsync(false, "~/");

            Assert.IsType<LocalRedirectResult>(result);

            var redirect = result as LocalRedirectResult;

            Assert.Equal("~/", redirect.Url);
        }
    }
}