using System.Collections.Generic;
using PokemonGym.API.Models;

namespace PokemonGym.API.Dtos
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}