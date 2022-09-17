using System.Text.Json.Serialization;

namespace CoffeeStore.UI.Data.Models
{
    public record CoffeeProduct : ProductItem
    {
        [JsonPropertyName("sort")]
        public Guid? Sort { get; set; }

        [JsonPropertyName("origin")]
        public string? Origin { get; set; }

        [JsonPropertyName("strength")]
        public Guid? Strength { get; set; }
    }
}
