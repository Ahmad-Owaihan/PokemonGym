using System.Collections.Generic;

namespace PokemonGym.API.Models
{
    public class ScoreRow
    {
        public int Id { get; set; }
        public ICollection<ScoreNumber> Row { get; set; }
        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
        public Participant Participant { get; set; }
        public int ParticipantId { get; set; }
    }
}