using AutoMapper;
using IdentityByExamples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityByExamples.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AccountController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }

            var user = _mapper.Map<User>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(userModel);
            }

            await _userManager.AddToRoleAsync(user, "Visitor");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}