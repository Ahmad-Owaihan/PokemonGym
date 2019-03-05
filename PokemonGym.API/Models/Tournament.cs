using System;
using System.Collections.Generic;

namespace PokemonGym.API.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<ScoreRow> Scores { get; set; }
        public Club Club { get; set; }
        public int ClubId { get; set; }
        public bool HasStarted { get; set; }
    }
}