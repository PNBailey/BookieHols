using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookieHols.API.Models;
using BookieHols.API.Models.DTOs;
using BookieHols.API.Services;

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

        /// <summary>
        /// Initializes a new instance of the AccouintRepository class.
        /// </summary>
        /// <param name="userManager">The UserManager instance.</param>
        /// <param name="signInManager">The SignInManager instance.</param>
        /// <param name="mapper">The IMapper instance.</param>
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        /// <summary>
        /// asynchronous validation for the apps register form. Checks whether the username already exists
        /// </summary>
        /// <param name="username">The username string to check</param>
        /// <returns>a boolean confirming whether the username already exists</returns>
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
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            //if (await _userManager.Users.AnyAsync(user => user.UserName == registerDto.Username.ToLower()))
            //{
            //    return BadRequest("Username is already taken");
            //}

            var appUser = _mapper.Map<User>(registerDto);
            appUser.UserName = registerDto.Username.ToLower();

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var userDto = _mapper.Map<UserDto>(appUser);
            return userDto;
        }
    }
}
