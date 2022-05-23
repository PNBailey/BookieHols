using Microsoft.AspNetCore.Identity;

namespace BookieHols.API.Models
{
    /// <summary>
    ///The Model object for a User
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// The <see cref="AppUserRole"/>s.
        /// </summary>
        public ICollection<AppUserRole> UserRoles { get; set; } = null!;
    }
}