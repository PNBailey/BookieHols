using System.Net;
using BookieHols.API.Models;

namespace BookieHols.API.DAL
{
    /// <summary>
    /// The Movie Database Repository. For more info on this 3rd party API, see <see href="https://developers.themoviedb.org/3/getting-started/introduction">here</see>
    /// </summary>
    public class MovieDatabaseRepository : IMovieDatabaseRepository
    {
        //<inheritdoc>//
        public async Task<HttpResponseMessage> RequestToken()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org/");

                    HttpResponseMessage response = await client.GetAsync("3/authentication/token/new?api_key=0750f28763f00a2e83ac3403aa225cad");

                    if (response.IsSuccessStatusCode)
                    {
                        return response;
                    } 

                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            
        }
    }
}
