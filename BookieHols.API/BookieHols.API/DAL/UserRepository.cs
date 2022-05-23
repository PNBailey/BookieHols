using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookieHols.API.Models;
using System.Net;

namespace BookieHols.API.DAL
{
    /// <summary>
    /// The User Repository Data Access Layer
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context"> The Data Context for the User DbContext</param>
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        //<inheritdoc>//
        public void DeleteUser(int id)
        {
            var user = _context.Users
                   .SingleOrDefault(u => u.Id == id);

            _context.Users.Remove(user);

        }

        //<inheritdoc>//
        public async Task<User> GetUser(int id)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        //<inheritdoc>//
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //<inheritdoc>//
        public async void PostUser(User user)
        {
            await _context.Users.AddAsync(user);

            _context.SaveChanges();
        }

        //<inheritdoc>//
        public async void PutUser(int id, User user)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

            existingUser = user;

            _context.SaveChanges();
        }
    }
}