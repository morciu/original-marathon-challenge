using AutoMapper;
using Domain.Models;
using WebApi.Dto;
using WebAPI.Dto;

namespace WebAPI.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivityGetDto>()
                .ForMember(a => a.LikeCount, opt => opt.MapFrom(a => a.Likes.Count()));
        }
    }
}
