using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class TestUserManager : UserManager<IdentityUser>
    {
        public TestUserManager()
            : base(new Mock<IUserStore<IdentityUser>>().Object,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<IdentityUser>>().Object,
                    new IUserValidator<IdentityUser>[0],
                    new IPasswordValidator<IdentityUser>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        { }

        public override Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(new IdentityUser { Email = email });
        }

        public override Task<bool> IsEmailConfirmedAsync(IdentityUser user)
        {
            return Task.FromResult(user.Email == "test@test.com");
        }

        public override Task<string> GeneratePasswordResetTokenAsync(IdentityUser user)
        {
            return Task.FromResult("---------------");
        }
    }
}
