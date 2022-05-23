using BookieHols.API.DAL;
using BookieHols.API.Models;

namespace BookieHols.API.Services
{
    /// <summary>
    /// The User Service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes an instance of the UserService
        /// </summary>
        /// <param name="userRepository">The User data access layer repository</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //<inheritdoc>//
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        //<inheritdoc>//
        public Task<User> GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        //<inheritdoc>//
        public Task<IEnumerable<User>> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        //<inheritdoc>//
        public void PostUser(User user)
        {
            _userRepository.PostUser(user);
        }

        //<inheritdoc>//
        public void PutUser(int id, User user)
        {
            _userRepository.PutUser(id, user);
        }
    }
}
