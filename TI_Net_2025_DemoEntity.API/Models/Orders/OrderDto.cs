namespace TI_Net_2025_DemoEntity.API.Models.Orders;

public record OrderDto
{
    public int Id { get; set; }
    public int Discount { get; set; }
    public int UserId { get; set; }
    public IEnumerable<OrderLineDto> OrderLines { get; set; } = [];
}