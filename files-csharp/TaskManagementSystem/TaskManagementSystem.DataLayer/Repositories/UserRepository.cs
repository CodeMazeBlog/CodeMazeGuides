using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManagementSystem.DataLayer.DbContexts;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.DataLayer.Entities;
using TaskManagementSystem.DataLayer.Interfaces;
using TaskManagementSystem.Domain.Enums;
using TaskManagementSystem.Domain.Models;

namespace TaskManagementSystem.DataLayer.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<Claim>?> LoginAsync(LoginModel model)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync(x => x.UserName == model.UserName);
            if (user is null) return null;
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            return await GetClaimsAsync(user);
        }

        public async Task<RegisterResultDto> RegisterAsync(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                all
            };
            var registerResult = await _userManager.CreateAsync(user, model.Password);
            if (!registerResult.Succeeded)
                return new RegisterResultDto(succeeded: false,
                    errorMessages: registerResult.Errors.Select(x => x.Description));
            var roles = new List<UserRoles> { model.Role }
                .Select(x => x.ToString());
            var roleResult = await _userManager.AddToRolesAsync(user, roles);
            if (!roleResult.Succeeded)
                return new RegisterResultDto(succeeded: false,
                    errorMessages: registerResult.Errors.Select(x => x.Description));
            var claims = await GetClaimsAsync(user);
            return new RegisterResultDto(succeeded: true, claims: claims);
        }

        public async Task<bool> DisableUser(string userId)
        {
            var user = await _context.Users
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null) return false;
            user.IsActive = false;
            return true;
        }

        public async Task<bool> ExistsAsync(string userId)
        {
            return await _context.Users
                .Where(x => x.IsActive)
                .AnyAsync(x => x.Id == userId);
        }

        private async Task<List<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            return claims.ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
