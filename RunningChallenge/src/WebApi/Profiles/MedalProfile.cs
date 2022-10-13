using AutoMapper;
using Domain.Models;
using WebApi.Dto;

namespace WebApi.Profiles
{
    public class MedalProfile : Profile
    {
        public MedalProfile()
        {
            CreateMap<Medal, MedalGetDto>();
        }
    }
}
