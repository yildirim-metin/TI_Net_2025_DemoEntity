namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string? Description { get; set; }

        public List<OrderLine> Lines { get; set; } = [];
        public List<StockMovement> Movements { get; set; } = [];
        public Stock? Stock { get; set; }
    }
}
