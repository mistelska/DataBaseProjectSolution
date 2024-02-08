using DataBaseProject.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataBaseProject.Repositories;
internal class Repo<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public Repo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
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
    public async Task<IEnumerable<TEntity>> GetAllFromList()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
            return null!;
        }
    }
    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
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

    public async Task<TEntity> Update(Expression<Func<TEntity, bool>> expression,TEntity entity)
    {
        try
        {
            var entityWillUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            _context.Entry(entityWillUpdate!).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

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

    public async Task Delete (Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            _context.Remove(entity!);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine($"Something went wrong: {ex.Message}");
            Console.ReadKey();
        }
    }
}
