using AutoMapper;
using FutbolDataAPI.Models;
using FutbolDataAPI.Models.DTOs;

namespace FutbolDataAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDTO>();
            CreateMap<Player, PlayerNameDto>();
            CreateMap<Club, ClubDTO>();
        }
    }
}
