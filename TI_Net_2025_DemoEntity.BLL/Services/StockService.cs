using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services;

public class StockService
{
    private readonly StockRepository _stockRepository;

    public StockService(StockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public void CreateStock(Stock stock)
    {
        _stockRepository.Add(stock);
    }
}
