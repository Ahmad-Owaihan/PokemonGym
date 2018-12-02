using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonGym.API.Models;

namespace PokemonGym.API.Data
{
    public interface ITournamentRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Tournament>> GetTournaments();
        Task<Tournament> GetTournament(int id);
        Task<User> GetUser(int id);
    }
}