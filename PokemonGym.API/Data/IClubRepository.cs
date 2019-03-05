using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public interface IClubRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Club>> GetClubs();
        Task<Club> GetClub(int id);
        Task<User> GetUser(int id);
        Task<IEnumerable<MemberApplicant>> GetApplicants(int id);
        Task<MemberApplicant> GetApplicant(int id);
        Task<Member> GetMember(int id);
    }
}