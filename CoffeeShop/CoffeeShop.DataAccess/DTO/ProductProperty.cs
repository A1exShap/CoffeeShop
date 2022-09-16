namespace CoffeeStore.DataAccess.Dto
{
    public partial class ProductProperty
    {
        public ProductProperty()
        {
            ProductPropertyValues = new HashSet<ProductPropertyValue>();
        }

        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; } = null!;
        public short ValueType { get; set; }
        public bool IsActive { get; set; }

        public virtual ProductType ProductType { get; set; } = null!;
        public virtual ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
