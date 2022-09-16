namespace CoffeeStore.DataAccess.Dto
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
