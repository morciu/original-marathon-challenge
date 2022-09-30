using AutoMapper;
using Domain.Models;
using WebApi.Dto;
using WebAPI.Dto;

namespace WebAPI.Profiles
{
    public class MarathonProfile : Profile
    {
        public MarathonProfile()
        {
            CreateMap<Marathon, MarathonGetDto>();
            CreateMap<Marathon, MarathonListGetDto>();
            CreateMap<MarathonPutPostDto, Marathon>();
        }
    }
}
