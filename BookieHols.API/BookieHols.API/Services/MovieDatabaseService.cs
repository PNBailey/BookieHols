using BookieHols.API.DAL;
using BookieHols.API.Models;

namespace BookieHols.API.Services
{
    /// <summary>
    /// The Movie Database Service. For more info on this 3rd party API, see <see href="https://developers.themoviedb.org/3/getting-started/introduction">here</see>
    /// </summary>
    public class MovieDatabaseService : IMovieDatabaseService
    {
        private readonly IMovieDatabaseRepository _movieDatabaseRepository;
        public MovieDatabaseService(IMovieDatabaseRepository movieDatabaseRepository)
        {
            _movieDatabaseRepository = movieDatabaseRepository;
        }

        //<inheritdoc>//
        public Task<HttpResponseMessage> RequestToken()
        {
            return _movieDatabaseRepository.RequestToken();
        }
    }
}
