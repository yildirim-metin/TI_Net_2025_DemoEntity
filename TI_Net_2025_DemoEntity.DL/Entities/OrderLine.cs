namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public OrderLineStatus Status { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
