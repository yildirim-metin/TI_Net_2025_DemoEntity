namespace TI_Net_2025_DemoEntity.API.Models.Orders;

public record class OrderLineDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
}
