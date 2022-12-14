using System.Text.Json.Serialization;

namespace CoffeeStore.Domain
{
    public sealed record CoffeeMachineProduct : ProductItem
    {
        [JsonPropertyName("guaranteePeriod")]
        public int GuaranteePeriod { get; set; }

        [JsonPropertyName("machineType")]
        public Guid? MachineType { get; set; }

        [JsonPropertyName("hasCoffeeGrinder")]
        public bool HasCoffeeGrinder { get; set; }

        [JsonPropertyName("hasCappuccinatore")]
        public bool HasCappuccinatore { get; set; }
    }
}
