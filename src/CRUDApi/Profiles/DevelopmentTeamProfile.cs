using AutoMapper;
using CRUDApi.DTOs;

namespace CRUDApi.Profiles
{
    public class DevelopmentTeamProfile : Profile
    {
        public DevelopmentTeamProfile()
        {
            CreateMap<Models.DevelopmentTeam, DevelopmentTeamCreateDTO>().ReverseMap();
            CreateMap<Models.DevelopmentTeam, DevelopmentTeamReadDTO>().ReverseMap();
            CreateMap<Models.DevelopmentTeam, DevelopmentTeamUpdateDTO>().ReverseMap();
            CreateMap<Models.DevelopmentTeam, DevelopmentTeamUpdateDTO>().ReverseMap();
        }
    }
}
