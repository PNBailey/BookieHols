using BookieHols.API.Models;

namespace BookieHols.API.DAL
{
    /// <summary>
    /// The Interface for the Movie Database Repository
    /// </summary>
    public interface IMovieDatabaseRepository
    {
        /// <summary>
        /// Creates a new Request Token from the Movie Database API. For more info see <see href="https://developers.themoviedb.org/3/authentication/create-request-token">here</see>
        /// </summary>
        /// <returns>A <see cref="HttpResponseMessage"/></returns>
        Task<HttpResponseMessage> RequestToken();
    }
}
