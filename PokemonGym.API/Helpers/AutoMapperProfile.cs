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
            CreateMap<Participant, ParticipantDto>()
            .ForMember( dest => dest.Name, opt => {
                opt.MapFrom(src => src.User.Username);
                });
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailsDto>();
            CreateMap<ScoreRow, ScoreDto>();
            CreateMap<ScoreNumberDto, ScoreNumber>();
            CreateMap<ScoreNumber, ScoreNumberDto>();
        }
    }
}