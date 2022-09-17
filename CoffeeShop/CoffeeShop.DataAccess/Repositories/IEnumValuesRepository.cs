namespace CoffeeStore.DataAccess.Repositories
{
    public interface IEnumValuesRepository
    {
        Task<Guid> GetEnumValueId(string valueName, string? stringValue = null, decimal? numericValue = null);

        Task<Dictionary<Guid, string>> GetValues(string parameterName);
    }
}
