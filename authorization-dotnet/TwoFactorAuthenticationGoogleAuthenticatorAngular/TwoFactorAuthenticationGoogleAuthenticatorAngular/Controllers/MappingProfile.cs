using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.Models;
using AutoMapper;

namespace TwoFactorAuthenticationGoogleAuthenticatorAngular.Controllers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
