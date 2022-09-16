namespace CoffeeStore.DataAccess.Dto
{
    public partial class PropertyEnum
    {
        public PropertyEnum()
        {
            PropertyEnumValues = new HashSet<PropertyEnumValue>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public short ValueType { get; set; }

        public virtual ICollection<PropertyEnumValue> PropertyEnumValues { get; set; }
    }
}
