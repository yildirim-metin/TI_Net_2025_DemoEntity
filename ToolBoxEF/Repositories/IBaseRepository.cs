namespace ToolBoxEF.Repositories;

public interface IBaseRepository<Entity> where Entity : class
{
    IEnumerable<Entity> FindMany(Func<Entity, bool>? predicate = null);
    Entity? FindOne(params object[] ids);
    Entity? FindOne(Func<Entity, bool> predicate);
    bool Any(Func<Entity, bool> predicate);
    Entity Add(Entity entity);
    void Add(IEnumerable<Entity> entities);
    bool Update(Entity entity);
    bool Delete(Entity entity);
    long Count(Func<Entity, bool>? predicate = null);
}
