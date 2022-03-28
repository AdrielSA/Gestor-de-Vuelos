using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVueloRepository : IRepository<Vuelo>
    {
        Task AddAsync(string currentUserId, Vuelo vuelo);
        Task<IEnumerable<Vuelo>> GetAllAsync(string rol);
        Task UpdateAsync(int id, Vuelo vuelo);
    }
}