using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
            if (vuelo.Partida >= vuelo.Regreso)
                throw new CustomException("La fecha de regreso debe ser posterior a la fecha de partida.");
            var entity = await GetAsync(id);
            entity.Origen = vuelo.Origen;
            entity.Destino = vuelo.Destino;
            entity.Partida = vuelo.Partida;
            entity.Regreso = vuelo.Regreso;
            entity.Pasajeros = vuelo.Pasajeros;
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddAsync(string currentUserId, Vuelo vuelo)
        {
            if (vuelo.Partida >= vuelo.Regreso)
                throw new CustomException("La fecha de regreso debe ser posterior a la fecha de partida.");
            vuelo.UsuarioId = Convert.ToInt32(currentUserId);
            await entities.AddRangeAsync(vuelo);
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
