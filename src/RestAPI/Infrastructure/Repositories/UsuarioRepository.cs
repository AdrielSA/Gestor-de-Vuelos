using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly IPasswordService service;

        public UsuarioRepository(GestorVuelosContext context, IPasswordService service) : base(context)
        {
            this.service = service;
        }

        public async Task UpdateAsync(int id, Usuario usuario)
        {
            var entity = await GetAsync(id);
            entity.Nombre = usuario.Nombre;
            entity.Correo = usuario.Correo;
            entity.Contraseña = service.HashingPass(usuario.Contraseña);
            entity.CodigoRol = usuario.CodigoRol;
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Usuario> GetByLogin(string correo)
        {
            return await entities.Include(e => e.CodigoRolNavigation).Where(x => x
                .Correo.ToLower().Equals(
                correo.ToLower())).SingleOrDefaultAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            usuario.CodigoRol = "OFIC";
            usuario.Contraseña = service.HashingPass(usuario.Contraseña);
            await entities.AddAsync(usuario);
            await context.SaveChangesAsync();
        }
    }
}
