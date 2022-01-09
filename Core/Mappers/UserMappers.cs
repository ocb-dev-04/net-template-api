using AutoMapper;

using Core.DTOs;
using Core.Entities;

namespace Core.Mappers
{
    /// <summary>
    /// User DTO mapper
    /// </summary>
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            CreateMap<User, FullUserDTO>()
                .ReverseMap(); // to single result
        }
    }
}
