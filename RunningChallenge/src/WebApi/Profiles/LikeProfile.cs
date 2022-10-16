using AutoMapper;
using Domain.Models;
using WebApi.Dto;

namespace WebApi.Profiles
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<Like, LikeGetDto>();
            CreateMap<LikePutPostDto, Like>();
        }
    }
}
