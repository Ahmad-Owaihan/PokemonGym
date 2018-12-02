using System.Collections.Generic;
using PokemonGym.API.Models;

namespace PokemonGym.API.Dtos
{
    public class ScoreDto
    {
        public int TournamentId { get; set; }
        public int ParticipantId { get; set; }
        public List<ScoreNumber> ScoreRow { get; set; }
    }
}