namespace CoffeeShop.DataAccess.Models
{
    public partial class Price
    {
        public Guid ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal VendorPrice { get; set; }
        public decimal SellingPrice { get; set; }

        public virtual Product? Product { get; set; }
    }
}
