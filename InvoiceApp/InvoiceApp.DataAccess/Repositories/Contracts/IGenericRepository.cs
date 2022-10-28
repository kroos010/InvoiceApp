using System.Linq.Expressions;

namespace InvoiceApp.DataAccess.Repositories.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null);
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
    
    // T? GetById(Guid id);
    // IEnumerable<T> GetAll();
    // IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    // Guid Add(T entity);
    // void AddRange(IEnumerable<T> entities);
    // void Remove(T entity);
    // void RemoveRange(IEnumerable<T> entities);
}