using AutoMapper;
using Domain.Models;
using WebAPI.Dto;

namespace WebAPI.Profiles
{
    public class MarathonProfile : Profile
    {
        public MarathonProfile()
        {
            CreateMap<Marathon, MarathonGetDto>();
            CreateMap<MarathonPutPostDto, Marathon>();
        }
    }
}
