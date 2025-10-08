namespace TI_Net_2025_DemoEntity.API.Models.Products;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string? Description { get; set; }
}