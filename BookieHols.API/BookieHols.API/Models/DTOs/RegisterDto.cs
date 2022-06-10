using FluentValidation;

namespace BookieHols.API.Models.DTOs
{
    /// <summary>
    /// A Dto to register a <see cref="User"/>.
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// Gets or Sets the UserName of the <see cref="User"/>.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the <see cref="User"/>s Password.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the <see cref="User"/>s Email.
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }

    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        /// <summary>
        /// A Fluent Validation Validator to Validate the User when they first register. See Fluent Validation documentation here: <see href="https://docs.fluentvalidation.net/en/latest/index.html"/>.
        /// </summary>
        public RegisterValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty();
                //.Matches("^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
