using API.DTOs;
using API.Entitites;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser,MemberDto>();
            CreateMap<Photo,PhotoDto>();
        }
    }
}