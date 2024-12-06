using System.Linq.Expressions;
using _.Models;

namespace _.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    
}
