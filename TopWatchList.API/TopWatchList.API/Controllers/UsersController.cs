using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopWatchList.API.Models;
using TopWatchList.API.Services;

namespace TopWatchList.API.Controllers
{
    /// <summary>
    /// The Users Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes and instance of the UsersController
        /// </summary>
        /// <param name="userService">An instance of the userService.</param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all the <see cref="User"/>s of the application
        /// </summary>
        /// <returns>A list of <see cref="User"/>s.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();

            return Ok(users);
        }

        /// <summary>
        /// Gets a single <see cref="User"/>
        /// </summary>
        /// <param name="id">The Id of the <see cref="User"/>.</param>
        /// <returns>A single <see cref="User"./></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }

        /// <summary>
        /// Upserts a <see cref="User"/>
        /// </summary>
        /// <param name="id">The Id of the <see cref="User"/>.</param>
        /// <param name="user">The <see cref="User"/> to upsert</param>
        /// <returns>A 204 response code if successful.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userService.PutUser(id, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Adds a new <see cref="User"/>
        /// </summary>
        /// <param name="user">The <see cref="User"/> to add.</param>
        /// <returns>A 204 response if successful.</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                _userService.PostUser(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a <see cref="User"/>
        /// </summary>
        /// <param name="id">The Id of the <see cref="User"/>.</param>
        /// <returns>A 204 response of successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return NoContent();
        }

        /// <summary>
        /// A private method which checks whether a <see cref="User"/> exists.
        /// </summary>
        /// <param name="id">The Id of the <see cref="User"/>.</param>
        /// <returns>A boolean.</returns>
        private bool UserExists(int id)
        {
            var user = _userService.GetUser(id);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}