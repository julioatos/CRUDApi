using AutoMapper;
using CRUDApi.DTOs;
using CRUDApi.Models;

namespace CRUDApi.Profiles
{
    public class DevelopmentTeamProfile : AutoMapper.Profile
    {
        public DevelopmentTeamProfile()
        {
            CreateMap<DevelopmentTeam, DevelopmentTeamCreateDTO>().ReverseMap();
            CreateMap<DevelopmentTeam, DevelopmentTeamReadDTO>().ReverseMap();
            CreateMap<DevelopmentTeam, DevelopmentTeamUpdateDTO>().ReverseMap();
            CreateMap<DevelopmentTeam, DevelopmentTeamUpdateDTO>().ReverseMap();
        }
    }
}
