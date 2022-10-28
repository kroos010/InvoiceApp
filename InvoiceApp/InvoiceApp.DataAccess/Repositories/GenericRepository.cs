using System.Linq.Expressions;
using InvoiceApp.DataAccess.Persistence;
using InvoiceApp.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.DataAccess.Repositories;

// public class GenericRepository<T> : IGenericRepository<T> where T :class
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationContext _context;
    protected readonly DbSet<TEntity> DbSet;
    
    public GenericRepository(ApplicationContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate == null)
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        // var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();
        // if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

        return await DbSet.Where(predicate).FirstOrDefaultAsync();
    }
    
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return _context.Find<TEntity>(id);
    }
    
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        // await _context.SaveChangesAsync();

        return addedEntity;
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        // await _context.SaveChangesAsync();

        return entity;
    }
    
    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        // await _context.SaveChangesAsync();

        return removedEntity;
    }
    
    
    // public Guid Add(T entity)
    // {
    //     _context.Set<T>().Add(entity);
    //     var IdProperty = entity.GetType().GetProperty("Id").GetValue(entity,null);
    //     
    //     return (Guid)IdProperty;
    // }
    // public void AddRange(IEnumerable<T> entities)
    // {
    //     _context.Set<T>().AddRange(entities);
    // }
    // public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    // {
    //     return _context.Set<T>().Where(expression);
    // }
    // public IEnumerable<T> GetAll()
    // {
    //     return _context.Set<T>().ToList();
    // }
    // public T GetById(Guid id)
    // {
    //     return _context.Set<T>().Find(id);
    // }
    // public void Remove(T entity)
    // {
    //     _context.Set<T>().Remove(entity);
    // }
    // public void RemoveRange(IEnumerable<T> entities)
    // {
    //     _context.Set<T>().RemoveRange(entities);
    // }
}