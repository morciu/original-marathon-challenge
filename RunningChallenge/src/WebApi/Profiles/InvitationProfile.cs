using AutoMapper;
using Domain.Models;
using WebApi.Dto;

namespace WebApi.Profiles
{
    public class InvitationProfile : Profile
    {
        public InvitationProfile()
        {
            CreateMap<Invitation, InvitationGetDto>();
        }
    }
}
