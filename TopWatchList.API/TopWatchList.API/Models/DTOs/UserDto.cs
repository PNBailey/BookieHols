﻿namespace TopWatchList.API.Models.DTOs
{
    /// <summary>
    /// A Dto for the <see cref="User"/> Entity
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or Sets the Id of the <see cref="User"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the UserName of the <see cref="User"/>.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the Name of the <see cref="User"/>.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}