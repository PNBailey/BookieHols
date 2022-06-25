using FluentValidation;

namespace BookieHols.API.Models.DTOs
{
    /// <summary>
    /// A Dto to login a <see cref="User"/>.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Gets or Sets the UserName of the <see cref="User"/>.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the <see cref="User"/>s Password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }

    public class LoginValidator : AbstractValidator<LoginDto>
    {
        /// <summary>
        /// A Fluent Validation Validator to Validate the User when they login. See Fluent Validation documentation here: <see href="https://docs.fluentvalidation.net/en/latest/index.html"/>.
        /// </summary>
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}