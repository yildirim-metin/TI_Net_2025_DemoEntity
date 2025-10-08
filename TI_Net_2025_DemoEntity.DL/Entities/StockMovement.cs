namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }

        public Product? Product { get; set; }
        public MovementLocation? From { get; set; }
        public MovementLocation? To { get; set; }
    }
}
