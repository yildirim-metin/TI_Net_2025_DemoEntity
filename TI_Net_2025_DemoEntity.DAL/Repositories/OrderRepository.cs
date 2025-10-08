using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(DemoEntityContext context) : base(context)
    {
    }

    public void TakeOrder(int userId, List<int> productId)
    {
    }
}