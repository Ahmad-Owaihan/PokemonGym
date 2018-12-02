using System.Collections.Generic;

namespace PokemonGym.API.Models
{
    public class Participant
    {
        public int Id { get; set; } 
        public int Score { get; set; }  
        public User User { get; set; }
        public int UserId { get; set; }
        public Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
        public ICollection<ScoreRow> Scores { get; set; }
    }
}