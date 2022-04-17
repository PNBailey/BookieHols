using Microsoft.AspNetCore.Identity;

namespace TopWatchList.API.Models
{
    /// <summary>
    /// The AppRole Model for use with Identity Framework
    /// </summary>
    public class AppRole : IdentityRole<int>
    {
        /// <summary>
        /// The <see cref="AppUserRole"/>s.
        /// </summary>
        public ICollection<AppUserRole> UserRoles { get; set; } = null!;
    }
}
