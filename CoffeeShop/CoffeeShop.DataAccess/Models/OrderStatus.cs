﻿namespace CoffeeShop.DataAccess.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public short Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
