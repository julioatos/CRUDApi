using AutoMapper;
using CRUDApi.DTOs;

namespace CRUDApi.Profiles
{
    public class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<Models.Profile, ProfileReadDTO>().ReverseMap();
            CreateMap<Models.Profile, ProfileCreateDTO>().ReverseMap();
        }
    }
}
