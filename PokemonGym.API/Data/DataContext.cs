using Microsoft.EntityFrameworkCore;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        public DbSet<User> Users { get; set; }
    }
}