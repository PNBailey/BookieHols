namespace TopWatchList.API.Models.DTOs
{
    /// <summary>
    /// A Dto to register a <see cref="User"/>.
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// Gets or Sets the UserName of the <see cref="User"/>.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the <see cref="User"/>s Password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
