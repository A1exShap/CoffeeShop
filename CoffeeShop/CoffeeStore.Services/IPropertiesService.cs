namespace CoffeeStore.Services
{
    public interface IPropertiesService
    {
        Task<Dictionary<Guid, string>> GetProductTypes();

        Task<Dictionary<Guid, string>> GetProperties(string propertyName);
    }
}
