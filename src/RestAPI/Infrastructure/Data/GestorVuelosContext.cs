using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public partial class GestorVuelosContext : DbContext
    {
        public GestorVuelosContext()
        {
        }

        public GestorVuelosContext(DbContextOptions<GestorVuelosContext> options) : base(options)
        {
        }

        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vuelo> Vuelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
