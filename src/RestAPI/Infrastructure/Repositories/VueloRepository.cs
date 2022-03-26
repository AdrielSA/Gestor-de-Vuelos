using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VueloRepository : Repository<Vuelo>, IVueloRepository
    {
        public VueloRepository(GestorVuelosContext context) : base(context)
        {
        }

        public async Task UpdateAsync(int id, Vuelo vuelo)
        {
            var entity = await GetAsync(id);
            entity.Origen = vuelo.Origen;
            entity.Destino = vuelo.Destino;
            entity.Partida = vuelo.Partida;
            entity.Regreso = vuelo.Regreso;
            entity.Pasajeros = vuelo.Pasajeros;
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vuelo>> GetAllAsync(string rol)
        {
            var AdminRol = await context.Roles.FirstOrDefaultAsync();
            return rol.Equals(AdminRol.Codigo) ? await entities
                .ToListAsync() : await entities
                .Include(x => x.Usuario)
                .Where(x => x.Usuario.CodigoRol
                .Equals(rol)).ToListAsync();
        }
    }
}
