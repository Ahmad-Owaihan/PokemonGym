using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly DataContext _context;
        public TournamentRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Tournament> GetTournament(int id)
        {
            var tournament = await _context.Tournaments
                .Include(x => x.Participants)
                .Include(x => x.Scores)
                .ThenInclude(x => x.Row)
                .FirstOrDefaultAsync(t => t.Id == id);
            return tournament;
        }

        public async Task<IEnumerable<Tournament>> GetTournaments()
        {
            var tournaments = await _context.Tournaments
            .Include(x => x.Participants)
            .Include(x => x.Scores)
            .ToListAsync();
            return tournaments;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}