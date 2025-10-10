using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public abstract class _BaseRepository<Entity> where Entity : BaseEntity
{
    protected DemoEntityContext _context;

    public _BaseRepository(DemoEntityContext context)
    {
        _context = context;
    }

    public virtual IEnumerable<Entity> GetAll(Func<Entity, bool>? predicate = null)
    {
        IEnumerable<Entity> query = _context.Set<Entity>();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return query;
    }

    public virtual Entity? GetOne(int id)
    {
        return _context.Set<Entity>().Find(id);
    }

    public virtual int Add(Entity entity)
    {
        _context.Set<Entity>().Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public virtual void Update(Entity entity)
    {
        _context.Set<Entity>().Update(entity);
        _context.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        Entity? entity = GetOne(id);

        if (entity is not null)
        {
            _context.Set<Entity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}