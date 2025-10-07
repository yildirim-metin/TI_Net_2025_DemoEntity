using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public class ProductRepository : BaseRepository<Product>
{
    public ProductRepository(DemoEntityContext context) : base(context)
    {
    }
}