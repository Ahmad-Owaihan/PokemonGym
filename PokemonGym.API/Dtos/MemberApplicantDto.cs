using System;
using System.Collections.Generic;
using PokemonGym.API.Models;

namespace PokemonGym.API.Dtos
{
    public class MemberApplicantDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Club Club { get; set; }
        public int ClubId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}