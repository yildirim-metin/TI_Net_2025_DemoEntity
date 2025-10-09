using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public class StockRepository : BaseRepository<Stock>
{
    public StockRepository(DemoEntityContext context) : base(context)
    {
    }

    public int GetStockByProductId(int productId)
    {
        return _context.Stocks.Where(s => s.ProductId == productId)
                              .Sum(s => s.CurrentQuantity);
    }
}
