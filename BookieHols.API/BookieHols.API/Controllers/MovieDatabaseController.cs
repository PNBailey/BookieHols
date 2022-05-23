using Microsoft.AspNetCore.Mvc;
using BookieHols.API.Services;

namespace BookieHols.API.Controllers
{
    /// <summary>
    /// The Movie Database Contoller
    /// </summary>
    public class MovieDatabaseController : BaseController
    {
        private readonly IMovieDatabaseService _movieDatabaseService;
        public MovieDatabaseController(IMovieDatabaseService movieDatabaseService)
        {
            _movieDatabaseService = movieDatabaseService;
        }

        /// <summary>
        /// Creates a new Request Token from the Movie Database API. For more info see <see href="https://developers.themoviedb.org/3/authentication/create-request-token">here</see>
        /// </summary>
        /// <returns>A <see cref="TokenRequest"/></returns>
        [HttpGet("RequestToken")]
        public Task<HttpResponseMessage> RequestToken()
        {
            return _movieDatabaseService.RequestToken();
        }

        // GET api/<MovieDatabaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieDatabaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieDatabaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieDatabaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
