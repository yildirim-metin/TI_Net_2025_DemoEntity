namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<User> Users { get; set; } = [];
    }
}
