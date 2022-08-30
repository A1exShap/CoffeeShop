namespace CoffeeShop.Domain
{
    public sealed record CoffeeMachine : ProductItem
    {
        public string? SerialNumber  { get; set; }

        public int WarrantyPeriod { get; set; }

        public CoffeeMachineType CoffeeMachineType { get; set; }

        public bool HasCofeeGrinder { get; set; }

        public bool CanWorkWithMilk { get; set; }
    }
}
