using AutoMapper;
using Domain.Models;
using WebAPI.Dto;

namespace WebAPI.Profiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<Activity, ActivityGetDto>();
        }
    }
}
