namespace CoffeeShop.DataAccess.Models
{
    public partial class ProductOperation
    {
        public string? Name { get; set; }
        public string? NomenclatureNumber { get; set; }
        public short OperationType { get; set; }
        public int? Amount { get; set; }
    }
}
