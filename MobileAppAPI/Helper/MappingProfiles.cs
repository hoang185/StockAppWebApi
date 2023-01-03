using AutoMapper;
using MobileAppAPI.Dto;
using MobileAppAPI.Models;

namespace MobileAppAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
