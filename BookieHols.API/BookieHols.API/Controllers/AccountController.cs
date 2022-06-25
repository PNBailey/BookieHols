using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookieHols.API.Models;
using BookieHols.API.Models.DTOs;
using BookieHols.API.Services;
using FluentValidation;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BookieHols.API.Controllers
{
    /// <summary>
    /// The AccountController class.
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the AccouintRepository class.
        /// </summary>
        /// <param name="userManager">The UserManager instance.</param>
        /// <param name="signInManager">The SignInManager instance.</param>
        /// <param name="mapper">The IMapper instance.</param>
        /// <param name="configuration">The IConfiguration instance.</param>
        public AccountController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IMapper mapper, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// asynchronous validation for the username. Checks whether the username already exists
        /// </summary>
        /// <param name="username">The username string to check</param>
        /// <returns>a boolean confirming whether the username already exists</returns> 
        [AllowAnonymous]
        [HttpGet("CheckUsername")]
        public async Task<ActionResult<bool>> CheckUsernameUnique([FromQuery]string username)
        {
            return !await _userManager.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

        /// <summary>
        /// asynchronous validation for the apps register form. Checks whether an account with that email already exists
        /// </summary>
        /// <param name="email">The email adddress string to check</param>
        /// <returns>a boolean confirming whether account with that email address already exists</returns>
        [AllowAnonymous]
        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> CheckEmailUnique([FromQuery] string email)
        {
            return !await _userManager.Users.AnyAsync(user => user.Email == email.ToLower());
        }

        /// <summary>
        /// Registers a user on the app.
        /// </summary>
        /// <param name="registerDto">The <see cref="RegisterDto"/>.</param>
        /// <returns>The <see cref="UserDto"/> if successful</returns>
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            if (userExists != null)
                return BadRequest("User already exists!");

            var registerValidator = new RegisterValidator();
            registerValidator.ValidateAndThrow(registerDto);

            var appUser = _mapper.Map<User>(registerDto);
            appUser.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var userDto = _mapper.Map<UserDto>(appUser);
            return userDto;
        }

        /// <summary>
        /// Logs in a user on the app.
        /// </summary>
        /// <param name="loginDto">The <see cref="LoginDto"/>.</param>
        /// <returns>The <see cref="UserDto"/> if successful</returns>
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            var loginValidator = new LoginValidator();
            loginValidator.ValidateAndThrow(loginDto);

            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if(user == null)
            {
                return BadRequest("No user found with that Username. Please click Register below to Register");
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);
                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = token;

                return Ok(userDto);
            }

            return Unauthorized();
        }

        /// <summary>
        /// Signs out the currently logged in User;
        /// </summary>
        [HttpPost("Logout")]
        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        } 

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
