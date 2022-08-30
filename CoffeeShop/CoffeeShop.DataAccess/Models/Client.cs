namespace CoffeeShop.DataAccess.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? DeliveryAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
