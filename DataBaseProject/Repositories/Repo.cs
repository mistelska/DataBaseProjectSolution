using DataBaseProject.Contexts;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;

namespace DataBaseProject.Repositories;
internal class Repo<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public Repo(ApplicationDbContext context)
    {
        _context = context;
    }

    public TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }
    public IEnumerable<TEntity> GetAllFromList()
    {
        return _context.Set<TEntity>().ToList();
    }
    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!;
    }

    public TEntity Update(Expression<Func<TEntity, bool>> expression,TEntity entity)
    {
        var entityWillUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(entityWillUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();

        return entityWillUpdate!;
    }

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();
    }
}
