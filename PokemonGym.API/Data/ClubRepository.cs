using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public class ClubRepository : IClubRepository
    {
        private readonly DataContext _context;
        public ClubRepository(DataContext context)
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

        public async Task<Club> GetClub(int id)
        {
            var club = await _context.Clubs
            .Include(c => c.Applications)
            .Include(c => c.Members)
            .Include(c => c.Tournaments)
            .FirstOrDefaultAsync(c => c.Id == id);
            return club;
        }

        public async Task<IEnumerable<Club>> GetClubs()
        {
            var clubs = await _context.Clubs
            .Include(c => c.Applications)
            .Include(c => c.Members)
            .Include(c => c.Tournaments)
            .ToListAsync();
            return clubs;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<MemberApplicant>> GetApplicants(int id)
        {
            var applicants = await _context.MemberApplications.Where(a => a.ClubId == id).ToListAsync();
            return applicants;
        }

        public async Task<MemberApplicant> GetApplicant(int id)
        {
            var applicant = await _context.MemberApplications.FirstOrDefaultAsync(a => a.Id == id);
            return applicant;
        }

        public async Task<Member> GetMember(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);
            return member;
        }
    }
}