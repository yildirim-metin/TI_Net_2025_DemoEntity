
using Microsoft.EntityFrameworkCore;

namespace ToolBoxEF.Repositories;

public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<Entity> _entities;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _entities = _context.Set<Entity>();
    }

    public bool Any(Func<Entity, bool> predicate)
    {
        return _entities.Any(predicate);
    }

    public long Count(Func<Entity, bool>? predicate = null)
    {
        return predicate is null ? _entities.Count() : _entities.Count(predicate);
    }

    public bool Delete(Entity entity)
    {
        _entities.Remove(entity);
        return _context.SaveChanges() == 1;
    }

    public IEnumerable<Entity> FindMany(Func<Entity, bool>? predicate = null)
    {
        return predicate is null ? _entities : _entities.Where(predicate);
    }

    public Entity? FindOne(params object[] ids)
    {
        return _entities.Find(ids);
    }

    public Entity? FindOne(Func<Entity, bool> predicate)
    {
        return _entities.SingleOrDefault(predicate);
    }

    public Entity Add(Entity entity)
    {
        _entities.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Update(Entity entity)
    {
        _entities.Update(entity);
        return _context.SaveChanges() == 1;
    }

    public void Add(IEnumerable<Entity> entities)
    {
        _entities.AddRange(entities);
        _context.SaveChanges();
    }
}
