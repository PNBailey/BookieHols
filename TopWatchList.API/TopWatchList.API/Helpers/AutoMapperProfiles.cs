using AutoMapper;
using TopWatchList.API.Models;
using TopWatchList.API.Models.DTOs;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>();

            CreateMap<User, UserDto>();
        }
    }
}
