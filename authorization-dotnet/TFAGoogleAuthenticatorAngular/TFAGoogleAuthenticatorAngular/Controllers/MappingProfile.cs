using TwoFactorAuthenticationGoogleAuthenticatorAngular.Models;
using AutoMapper;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.DataTransferObjects;

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
