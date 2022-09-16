using CoffeeStore.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.DataAccess.Repositories.Implementation
{
    internal class ProductTypesRepository : IProductTypesRepository, IDisposable
    {
        private readonly CoffeeStoreContext _dbContext;

        public ProductTypesRepository()
        {
            _dbContext = new CoffeeStoreContext();
        }

        public void Dispose() => _dbContext.Dispose();

        public Task<Guid> GetProductTypeId(string productTypeName)
            => _dbContext.ProductTypes.Where(type => type.Name == productTypeName)
                                          .Select(type => type.Id)
                                          .FirstAsync();
    }
}
