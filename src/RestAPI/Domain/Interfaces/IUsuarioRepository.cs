using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task AddAsync(Usuario usuario);
        Task<Usuario> GetByLogin(string correo);
        Task UpdateAsync(int id, Usuario usuario);
    }
}