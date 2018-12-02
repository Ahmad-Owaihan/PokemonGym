using System;
using System.Collections.Generic;
using PokemonGym.API.Models;

namespace PokemonGym.API.Dtos
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ParticipantDto> Participants { get; set; }
        public ICollection<ScoreRow> Scores { get; set; }
    }
}