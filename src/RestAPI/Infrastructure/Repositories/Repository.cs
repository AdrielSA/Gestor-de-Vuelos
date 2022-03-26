using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly GestorVuelosContext context;
        protected readonly DbSet<T> entities;

        public Repository(GestorVuelosContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await entities.FindAsync(id);
            if (entity.Equals(null))
                throw new ArgumentException("No se encontró una entidad con este ID.", "Id");
            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if(context != null) 
                await context.DisposeAsync();
        }
    }
}
