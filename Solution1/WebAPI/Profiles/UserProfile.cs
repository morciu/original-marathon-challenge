using AutoMapper;
using Domain.Models;
using WebAPI.Dto;

namespace WebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserPutPostDto, User>();
        }
    }
}
