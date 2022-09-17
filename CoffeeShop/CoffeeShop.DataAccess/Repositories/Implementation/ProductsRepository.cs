using CoffeeStore.DataAccess.Dto;
using CoffeeStore.DataAccess.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.DataAccess.Repositories.Implementation
{
    internal class ProductsRepository : IProductsRepository, IDisposable
    {
        private readonly CoffeeStoreContext _dbContext;

        public ProductsRepository()
        {
            _dbContext = new CoffeeStoreContext();
        }

        public void Dispose() => _dbContext.Dispose();

        public Task Delete(Product product)
        {
            _dbContext.Remove(product);
            return _dbContext.SaveChangesAsync();
        }

        public Task<Product[]> GetAllProducts()
        {
            return GetAllProductsInternal().ToArrayAsync();
        }

        public Task<Product[]> GetProductsByPartialName(string partialName)
        {
            return GetProductsByFilter(prod => prod.Name.StartsWith(partialName));
        }

        public Task<Product[]> GetProductsByType(Guid productTypeId)
        {
            return GetProductsByFilter(prod => prod.ProductTypeId == productTypeId);
        }

        public async Task<Guid> Upsert(Product product)
        {
            if (_dbContext.Products.Any(x => x.Id == product.Id))
                _dbContext.Update(product);
            else
            {
                product.Id = Guid.NewGuid();
                _dbContext.Add(product);
            }

            await _dbContext.SaveChangesAsync();

            return product.Id;
        }

        private IQueryable<Product> GetAllProductsInternal()
        {
            return _dbContext.Products
                             .AsNoTracking()
                             .Include(prod => prod.ProductPropertyValues)
                                .ThenInclude(val => val.Property)
                             .Include(prod => prod.ProductPropertyValues)
                                .ThenInclude(val => val.EnumValue)
                             .Include(val => val.ProductType)
                             .Include(prod => prod.Prices);
        }

        private Task<Product[]> GetProductsByFilter(Expression<Func<Product, bool>> filter)
        {
            var products = GetAllProductsInternal();
            return products.Where(filter).ToArrayAsync();
        }
    }
}
