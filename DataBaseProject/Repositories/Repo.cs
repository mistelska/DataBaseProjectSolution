using DataBaseProject.Contexts;
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
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public IEnumerable<TEntity> GetAllFromList()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            return entity!;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public TEntity Update(Expression<Func<TEntity, bool>> expression,TEntity entity)
    {
        try
        {
            var entityWillUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Entry(entityWillUpdate!).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return entityWillUpdate!;
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }

    public void Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Remove(entity!);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
