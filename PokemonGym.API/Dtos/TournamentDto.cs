using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PokemonGym.API.Models;

namespace PokemonGym.API.Dtos
{
    public class TournamentDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool HasStarted { get; set; }
        public IEnumerable<ParticipantDto> Participants { get; set; }
        public ICollection<ScoreDto> Scores { get; set; }
    }
}