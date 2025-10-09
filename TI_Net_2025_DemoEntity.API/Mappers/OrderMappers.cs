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
            Lines = [.. orderDto.OrderLines.Select(ol => ol.ToOrderLine())],
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

    public static OrderDto ToOrderDto(this Order order)
    {
        return new()
        {
            Id = order.Id,
            Discount = order.Discount,
            UserId = order.UserId,
            OrderLines = order.Lines.ToOrderLineDtos(),
        };
    }

    public static IEnumerable<OrderDto> ToOrderDtos(this IEnumerable<Order> orders)
    {
        return orders.Select(o => o.ToOrderDto());
    }

    public static OrderLineDto ToOrderLineDto(this OrderLine orderLine)
    {
        return new()
        {
            Id = orderLine.Id,
            ProductId = orderLine.ProductId,
            Quantity = orderLine.Quantity,
            Status = orderLine.Status.ToString(),
        };
    }

    public static IEnumerable<OrderLineDto> ToOrderLineDtos(this IEnumerable<OrderLine> orderLines)
    {
        return orderLines.Select(ol => ol.ToOrderLineDto());
    }
}
