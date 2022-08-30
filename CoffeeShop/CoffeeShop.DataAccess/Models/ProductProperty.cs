namespace CoffeeShop.DataAccess.Models
{
    public partial class ProductProperty
    {
        public ProductProperty()
        {
            ProductPropertyValues = new HashSet<ProductPropertyValue>();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public short ValueType { get; set; }
        public bool IsActive { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
