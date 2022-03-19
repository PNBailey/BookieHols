namespace TopWatchList.API.Models
{
    /// <summary>
    ///The Model object for a User
    /// </summary>
    public class User
    {
        /// <summary>
        /// The Id of the User
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the User
        /// </summary>
        public string? Name { get; set; }
    }
}