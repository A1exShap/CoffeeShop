using System.Text.Json.Serialization;

namespace CoffeeStore.UI.Data.Models;

public record ProductItem : IProductItem
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("nomenclatureNumber")]
    public string NomenclatureNumber { get; init; }

    [JsonPropertyName("productType")]
    public Guid ProductType { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("vendorPrice")]
    public decimal VendorPrice { get; init; }

    [JsonPropertyName("sellingPrice")]
    public decimal SellingPrice { get; init; }
}
