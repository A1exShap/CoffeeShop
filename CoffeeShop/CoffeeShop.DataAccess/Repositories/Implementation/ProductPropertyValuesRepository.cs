using CoffeeStore.DataAccess.Context;
using CoffeeStore.DataAccess.Dto;

namespace CoffeeStore.DataAccess.Repositories.Implementation
{
    internal class ProductPropertyValuesRepository : IProductPropertyValuesRepository, IDisposable
    {
        private readonly CoffeeStoreContext _dbContext;

        public ProductPropertyValuesRepository()
        {
            _dbContext = new CoffeeStoreContext();
        }

        public void Dispose() => _dbContext.Dispose();

        public Task Upsert(ProductPropertyValue propertyValue)
        {
            var value = _dbContext.ProductPropertyValues.Where(val => val.PropertyId == propertyValue.PropertyId 
                                                                   && val.ProductId == propertyValue.ProductId)
                                                        .Select(val => val)
                                                        .FirstOrDefault();

            if (value is null)
            {
                propertyValue.Id = Guid.NewGuid();
                _dbContext.Add(propertyValue);
            }
            else
            {
                value.StringValue = propertyValue.StringValue;
                value.NumericValue = propertyValue.NumericValue;
                value.EnumValueId = propertyValue.EnumValueId;
                _dbContext.Update(value);
            }

            return _dbContext.SaveChangesAsync();
        }
    }
}
