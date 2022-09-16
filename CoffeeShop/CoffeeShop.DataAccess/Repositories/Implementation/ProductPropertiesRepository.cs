using CoffeeStore.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.DataAccess.Repositories.Implementation
{
    internal class ProductPropertiesRepository : IProductPropertiesRepository, IDisposable
    {
        private readonly CoffeeStoreContext _dbContext;

        public ProductPropertiesRepository()
        {
            _dbContext = new CoffeeStoreContext();
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task<(Guid id, short valueType)> GetPropertyParameters(string propertyName)
        {
            var property = await _dbContext.ProductProperties.Where(prop => prop.Name == propertyName)
                                          .Select(prop => prop)
                                          .FirstAsync();

            return (property.Id, property.ValueType);
        }
    }
}
