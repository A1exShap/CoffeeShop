namespace CoffeeStore.Domain
{
    public sealed record CoffeeProduct : ProductItem
    {
        public string? Sort { get; set; }

        public string? Origin { get; set; }

        public int? Strength { get; set; }
    }
}
