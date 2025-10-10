using TI_Net_2025_DemoEntity.DL.Entities;
using ToolBoxEF.Repositories;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    IEnumerable<Product> GetProducts(int page = 0, Func<Product, bool>? predicate = null);
}
