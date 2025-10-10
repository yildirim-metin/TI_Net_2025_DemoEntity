using TI_Net_2025_DemoEntity.DL.Entities;
using ToolBoxEF.Repositories;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DemoEntityContext context) : base(context)
    {
    }

    public IEnumerable<Product> GetProducts(int page = 0, Func<Product, bool>? predicate = null)
    {
        throw new NotImplementedException();
    }
}