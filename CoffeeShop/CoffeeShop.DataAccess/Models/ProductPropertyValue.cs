namespace CoffeeShop.DataAccess.Models
{
    public partial class ProductPropertyValue
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Guid ProductId { get; set; }
        public string? StringValue { get; set; }
        public decimal? NumericValue { get; set; }
        public Guid? EnumValueId { get; set; }

        public virtual PropertyEnumValue? EnumValue { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ProductProperty? Property { get; set; }
    }
}
