using PokemonGym.API.Models;

namespace PokemonGym.API.Dtos
{
    public class ParticipantDto
    {
        public int Id { get; set; } 
        public int Score { get; set; }  
        public string PhotoUrl { get; set; }

        public int UserId { get; set; }
        public int TournamentId { get; set; }
    }
}