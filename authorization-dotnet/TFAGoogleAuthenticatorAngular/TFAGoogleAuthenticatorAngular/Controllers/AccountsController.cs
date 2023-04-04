using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Encodings.Web;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.Models;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.DataTransferObjects;
using TwoFactorAuthenticationGoogleAuthenticatorAngular.JwtFeatures;

namespace TwoFactorAuthenticationGoogleAuthenticatorAngular.Controllers
{
    [Route("api/accounts")]
    [EnableCors("two_factor_auth_cors")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private readonly UrlEncoder _urlEncoder;
        private readonly JwtHandler _jwtHandler;

        public AccountsController(UserManager<User> userManager, 
            IMapper mapper, 
            UrlEncoder urlEncoder,
            JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _urlEncoder = urlEncoder;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var isTfaEnabled = await _userManager.GetTwoFactorEnabledAsync(user);

            if(!isTfaEnabled)
            {
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(user);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthResponseDto { IsAuthSuccessful = true, IsTfaEnabled = false, Token = token });
            }

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, IsTfaEnabled = true });
        }

        [HttpPost("login-tfa")]
        public async Task<IActionResult> LoginTfa([FromBody] TfaDto tfaDto)
        {
            var user = await _userManager.FindByNameAsync(tfaDto.Email);

            if (user == null)
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var validVerification = await _userManager.VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, tfaDto.Code);
            if (!validVerification)
                return BadRequest("Invalid Token Verification");

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, IsTfaEnabled = true, Token = token });
        }

        [HttpGet("tfa-setup")]
        public async Task<IActionResult> GetTfaSetup(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
                return BadRequest("User does not exist");

            var isTfaEnabled = await _userManager.GetTwoFactorEnabledAsync(user);

            var authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            if (authenticatorKey == null)
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            }
            var formattedKey = GenerateQRCode(email, authenticatorKey);

            return Ok(new TfaSetupDto { IsTfaEnabled = isTfaEnabled, AuthenticatorKey = authenticatorKey, FormattedKey = formattedKey });
        }

        [HttpPost("tfa-setup")]
        public async Task<IActionResult> PostTfaSetup([FromBody] TfaSetupDto tfaModel)
        {
            var user = await _userManager.FindByNameAsync(tfaModel.Email);

            var isValidCode = await _userManager
                .VerifyTwoFactorTokenAsync(user, _userManager.Options.Tokens.AuthenticatorTokenProvider, tfaModel.Code);

            if (isValidCode)
            {
                await _userManager.SetTwoFactorEnabledAsync(user, true);
                return Ok(new TfaSetupDto { IsTfaEnabled = true });
            }
            else
            {
                return BadRequest("Invalid code");
            }
        }

        [HttpDelete("tfa-setup")]
        public async Task<IActionResult> DeleteTfaSetup(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }
            else
            {
                await _userManager.SetTwoFactorEnabledAsync(user, false);
                return Ok(new TfaSetupDto { IsTfaEnabled = false } );
            }
        }
        private string GenerateQRCode(string email, string unformattedKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                _urlEncoder.Encode("Code Maze Two-Factor Auth"),
                _urlEncoder.Encode(email),
                unformattedKey);
        }
    }
}
