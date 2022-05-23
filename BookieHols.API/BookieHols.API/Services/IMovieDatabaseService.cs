using BookieHols.API.Models;

namespace BookieHols.API.Services
{
    /// <summary>
    /// The Interface for the Movie Database Service
    /// </summary>
    public interface IMovieDatabaseService
    {
        /// <summary>
        /// Creates a new Request Token from the Movie Database API. For more info see <see href="https://developers.themoviedb.org/3/authentication/create-request-token">here</see>
        /// </summary>
        /// <returns>A <see cref="HttpResponseMessage"/></returns>
        Task<HttpResponseMessage> RequestToken();
    }
}
