using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public interface IUsersRepository
    {
        void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}