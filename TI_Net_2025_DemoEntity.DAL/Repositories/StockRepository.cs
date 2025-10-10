using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories;

public class StockRepository : _BaseRepository<Stock>
{
    public StockRepository(DemoEntityContext context) : base(context)
    {
    }

    public int GetStockQuantityByProductId(int productId)
    {
        return _context.Stocks.Where(s => s.ProductId == productId)
                              .Sum(s => s.CurrentQuantity);
    }

    public Stock? GetOnsiteStockByProductId(int productId)
    {
        return _context.Stocks.Include(s => s.Location)
                              .Where(s => s.ProductId == productId)
                              .Where(s => s.Location != null && s.Location.Name == "OnSite")
                              .FirstOrDefault();
    }

    public Stock? GetStockWareHouseByProductId(int productId)
    {
        return _context.Stocks.Include(s => s.Location)
                              .Where(s => s.ProductId == productId)
                              .Where(s => s.Location != null && s.Location.Name == "Warehouse")
                              .FirstOrDefault();
    }
}
