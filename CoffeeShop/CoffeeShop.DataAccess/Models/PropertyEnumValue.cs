namespace CoffeeShop.DataAccess.Models
{
    public partial class PropertyEnumValue
    {
        public PropertyEnumValue()
        {
            ProductPropertyValues = new HashSet<ProductPropertyValue>();
        }

        public Guid Id { get; set; }
        public Guid EnumId { get; set; }
        public string? StringValue { get; set; }
        public decimal? NumericValue { get; set; }

        public virtual PropertyEnum? Enum { get; set; }
        public virtual ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
