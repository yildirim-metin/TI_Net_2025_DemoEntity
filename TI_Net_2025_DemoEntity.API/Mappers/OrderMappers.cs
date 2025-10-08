using TI_Net_2025_DemoEntity.API.Models.Orders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.API.Mappers;

public static class OrderMappers
{
    public static Order ToOrder(this OrderDto orderDto)
    {
        return new()
        {
            Id = orderDto.Id,
            Date = DateTime.Now,
            Discount = orderDto.Discount,
            UserId = orderDto.UserId,
            Lines = [.. orderDto.OrderLines.Select(ol => ol.ToOrderLine())]
        };
    }

    public static OrderLine ToOrderLine(this OrderLineDto orderLineDto)
    {
        return new()
        {
            Id = orderLineDto.Id,
            Quantity = orderLineDto.Quantity,
            ProductId = orderLineDto.ProductId,
        };
    }
}
