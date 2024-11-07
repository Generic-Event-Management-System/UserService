using AutoMapper;
using UserService.Models.Dto;
using UserService.Models.Entities;

namespace UserService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
