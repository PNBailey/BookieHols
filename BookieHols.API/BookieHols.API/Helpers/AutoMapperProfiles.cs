using AutoMapper;
using BookieHols.API.Models;
using BookieHols.API.Models.DTOs;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, User>();

            CreateMap<User, UserDto>();

            CreateMap<LoginDto, User>();

            CreateMap<User, LoginDto>();
        }
    }
}
