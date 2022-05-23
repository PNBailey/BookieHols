namespace BookieHols.API.Models
{
    /// <summary>
    /// A Model for the Movie Database token request
    /// </summary>
    public class TokenRequest
    {
        /// <summary>
        /// Gets or Sets a value indiciating whether the token request was successful or not
        /// </summary>
        public bool RequestSuccessful { get; set; }

        /// <summary>
        /// Gets or Sets the expiry date/time for the token
        /// </summary>
        public string Expires { get; set; } = null!;

        /// <summary>
        /// Gets or Sets the Request Token
        /// </summary>
        public string RequestToken { get; set; } = null!;


    }
}
