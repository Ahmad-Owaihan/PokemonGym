using System;
using System.Collections.Generic;

namespace PokemonGym.API.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public DateTime DateClubStarted { get; set; }
        public Club()
        {
            this.DateClubStarted = DateTime.Now;
            this.IsActive = true;
        }
        public bool IsActive { get; set; }
        public DateTime DateLastTournament { get; set; }
        public List<MemberApplicant> Applications { get; set; }
    }
}