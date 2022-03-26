using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> : IAsyncDisposable where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task SaveChangesAsync();
    }
}