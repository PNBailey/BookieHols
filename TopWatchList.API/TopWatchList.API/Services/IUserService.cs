using TopWatchList.API.Models;

namespace TopWatchList.API.Services
{
    public interface IUserService
    {
        /// <summary>
        /// A method to get all users from the database
        /// </summary>
        /// <returns>A list of <see cref="User"/>s.</returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Gets a User by their Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="User"/>.</returns>
        Task<User> GetUser(int id);

        /// <summary>
        /// Upserts a User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        void PutUser(int id, User user);

        /// <summary>
        /// Adds a new User
        /// </summary>
        /// <param name="user"></param>
        void PostUser(User user);

        /// <summary>
        /// Deletes a User
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);
    }
}