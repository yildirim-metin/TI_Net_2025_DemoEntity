using Microsoft.EntityFrameworkCore;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(DemoEntityContext context) : base(context)
    {
    }

    public override IEnumerable<Order> GetAll(Func<Order, bool>? predicate = null)
    {
        IEnumerable<Order> query = _context.Set<Order>().Include(o => o.Lines);

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return query;
    }
}