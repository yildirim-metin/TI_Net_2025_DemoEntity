namespace TI_Net_2025_DemoEntity.API.Models.Stocks;

public record StockDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CurrentQuantity { get; set; }
    public int LimitQuantity { get; set; }
    public int LocationId { get; set; }
}
