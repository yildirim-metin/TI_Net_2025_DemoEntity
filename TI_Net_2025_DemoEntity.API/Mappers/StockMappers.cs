using TI_Net_2025_DemoEntity.API.Models.Stocks;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.API.Mappers;

public static class StockMappers
{
    public static Stock ToStock(this StockDto stockDto)
    {
        return new()
        {
            Id = stockDto.Id,
            CurrentQuantity = stockDto.CurrentQuantity,
            LimitQuantity = stockDto.LimitQuantity,
            ProductId = stockDto.ProductId,
            LocationId = stockDto.LocationId,
        };
    }
}
