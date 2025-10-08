namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Discount { get; set; }
        public int UserId { get; set; }

        public User? User { get; set; }
        public List<OrderLine> Lines { get; set; } = [];
    }
}
