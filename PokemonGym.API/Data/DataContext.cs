using Microsoft.EntityFrameworkCore;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ScoreRow> ScoreRows { get; set; }
        public DbSet<ScoreNumber> Scores { get; set; }
    }
}