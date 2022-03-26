using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GestorVuelosContext context) : base(context)
        {
        }

        public async Task UpdateAsync(int id, Usuario usuario)
        {
            var entity = await GetAsync(id);
            entity.Nombre = usuario.Nombre;
            entity.Correo = usuario.Correo;
            entity.CodigoRol = usuario.CodigoRol;
            entities.Update(entity);
        }

        public async Task<Usuario> GetByLogin(string correo)
        {
            return await entities.Where(x => x
                .Correo.ToLower().Equals(
                correo.ToLower())).FirstOrDefaultAsync();
        }
    }
}
