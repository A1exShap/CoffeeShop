using System.Text.Json.Serialization;

namespace CoffeeStore.Domain
{
    public sealed record CoffeeProduct : ProductItem
    {
        [JsonPropertyName("sort")]
        public Guid? Sort { get; set; }

        [JsonPropertyName("origin")]
        public string? Origin { get; set; }

        [JsonPropertyName("strength")]
        public Guid? Strength { get; set; }
    }
}
