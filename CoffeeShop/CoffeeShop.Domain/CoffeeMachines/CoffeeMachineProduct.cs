namespace CoffeeStore.Domain
{
    public sealed record CoffeeMachineProduct : ProductItem
    {
        public int GuaranteePeriod { get; set; }

        public string MachineType { get; set; }

        public bool HasCoffeeGrinder { get; set; }

        public bool HasCappuccinatore { get; set; }
    }
}
