namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public List<Role> Roles { get; set; } = [];
        public List<Order> Orders { get; set; } = [];
    }
}
