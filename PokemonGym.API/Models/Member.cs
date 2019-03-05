using System;
using System.Collections.Generic;

namespace PokemonGym.API.Models
{
    public class Member
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime DateJoined { get; set; }
        public Club Club { get; set; }
        public int ClubId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        // derived
        public int Points { get; set; }

        //derived
        public List<Tournament> History { get; set; }

        public Member(int userId, int clubId)
        {
            UserId = userId;
            ClubId = clubId;
            DateJoined = DateTime.Now;
        }
    }
}