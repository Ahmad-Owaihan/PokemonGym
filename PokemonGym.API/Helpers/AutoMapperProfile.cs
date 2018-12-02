using AutoMapper;
using PokemonGym.API.Dtos;
using PokemonGym.API.Models;

namespace PokemonGym.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tournament, TournamentDto>();
            CreateMap<Participant, ParticipantDto>();
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailsDto>();
            CreateMap<ScoreRow, ScoreDto>();
        }
    }
}