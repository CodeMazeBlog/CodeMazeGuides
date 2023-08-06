using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Application.Interfaces;
using TaskManagementSystem.DataLayer.Interfaces;
using TaskManagementSystem.Domain.Models;
using TaskManagementSystem.Exceptions.Exceptions;

namespace TaskManagementSystem.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<JwtTokenResponse> LoginAsync(LoginModel model)
        {
            var claims = await _userRepository.LoginAsync(model) ??
                throw new InvalidLoginException();
            var token = CreateToken(claims);
            return token;
        }

        public async Task<JwtTokenResponse> RegisterAsync(RegisterModel model)
        {
            var result = await _userRepository.RegisterAsync(model);
            if (!result.Succeeded || result.Claims is null || result.Claims.Count == 0)
                throw new RegisterFailedException(result.ErrorMessages);
            var token = CreateToken(result.Claims);
            return token;
        }

        public async Task DisableUser(string userId)
        {
            var isSucceeded = await _userRepository.DisableUser(userId);
            if (!isSucceeded)
                throw new UserNotFoundException(userId);
            await _userRepository.SaveChangesAsync();
        }

        private JwtTokenResponse CreateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Secret").Value));
            var expiresOn = DateTime.UtcNow.AddDays(1);
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                                   issuer: _configuration["JWT:ValidIssuer"],
                                   audience: _configuration["JWT:ValidAudience"],
                                   claims: claims,
                                   expires: expiresOn,
                                   signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return new JwtTokenResponse(jwt, expiresOn);
        }
    }
}
