using Microsoft.AspNetCore.Identity;

namespace BookieHols.API.Models
{
    /// <summary>
    /// The AppUserRole Model for use with Identityy Framework. This acts as the join table between the <see cref="User"/> table and the <see cref="AppRole"/>.
    /// </summary>
    public class AppUserRole : IdentityUserRole<int>
    {
        /// <summary>
        /// The <see cref="User"/>.
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// The <see cref="AppRole"/>.
        /// </summary>
        public AppRole Role { get; set; } = null!;
    }
}
