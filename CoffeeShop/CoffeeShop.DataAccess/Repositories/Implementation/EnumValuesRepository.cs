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
            var propertyId = _dbContext.PropertyEnums.Where(prop => prop.Name == valueName)
                                                     .Select(prop => prop.Id).First();

            return _dbContext.PropertyEnumValues.Where(val => val.EnumId == propertyId
                                                           && val.StringValue == stringValue
                                                           && val.NumericValue == numericValue)
                                                .Select(val => val.Id)
                                                .FirstAsync();
        }
    }
}
