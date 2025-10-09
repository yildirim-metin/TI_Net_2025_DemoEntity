namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class Stock : BaseEntity
    {
        public int CurrentQuantity { get; set; }
        public int? LimitQuantity { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }

        public Product? Product { get; set; }
        public MovementLocation? Location { get; set; }
    }
}
