using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PokemonGym.API.Models
{
    public class ClubDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}