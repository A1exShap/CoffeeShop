using CoffeeStore.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.DataAccess.Repositories.Implementation
{
    internal class EnumValuesRepository : IEnumValuesRepository, IDisposable
    {
        private readonly CoffeeStoreContext _dbContext;

        public EnumValuesRepository()
        {
            _dbContext = new CoffeeStoreContext();
        }

        public void Dispose() => _dbContext.Dispose();

        public Task<Guid> GetEnumValueId(string valueName, string? stringValue = null, decimal? numericValue = null)
        {
            var propertyId = GetPropertyId(valueName);

            return _dbContext.PropertyEnumValues.Where(val => val.EnumId == propertyId
                                                           && val.StringValue == stringValue
                                                           && val.NumericValue == numericValue)
                                                .Select(val => val.Id)
                                                .FirstAsync();
        }

        public async Task<Dictionary<Guid, string>> GetValues(string propertyName)
        {
            var propertyId = GetPropertyId(propertyName);

            var query = await _dbContext.PropertyEnumValues.Where(val => val.EnumId == propertyId)
                                                .Select(val => val)
                                                .ToListAsync();

            var result = new Dictionary<Guid, string>();

            if (query.Any(val => val.StringValue != null))
                foreach (var val in query.OrderBy(x => x.StringValue))
                    result.Add(val.Id, val.StringValue);

            else if (query.Any(val => val.NumericValue != null))
                foreach (var val in query.OrderBy(x => x.NumericValue))
                    result.Add(val.Id, val.NumericValue.ToString());
            
            else
                throw new ArgumentException($"Properties {propertyName} not found");

            return result;
        }

        private Guid GetPropertyId(string propertyName)
            => _dbContext.PropertyEnums.Where(prop => prop.Name == propertyName)
                                       .Select(prop => prop.Id).First();
    }
}
