namespace CoffeeStore.DataAccess.Dto
{
    public partial class ProductOperation
    {
        public string Name { get; set; } = null!;
        public string NomenclatureNumber { get; set; } = null!;
        public short OperationType { get; set; }
        public int? Amount { get; set; }
    }
}
