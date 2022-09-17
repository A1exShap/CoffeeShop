using CoffeeStore.DataAccess.Dto;
using CoffeeStore.DataAccess.Repositories;
using CoffeeStore.Domain;

namespace CoffeeStore.Services.Implementation
{
    internal class PropertiesService : IPropertiesService
    {
        private readonly IProductTypesRepository _productTypesRepository;
        private readonly IEnumValuesRepository _enumValuesRepository;

        public PropertiesService(IProductTypesRepository productTypesRepository,
                                 IEnumValuesRepository enumValuesRepository)
        {
            _productTypesRepository = productTypesRepository;
            _enumValuesRepository = enumValuesRepository;
        }

        public async Task<Dictionary<Guid, string>> GetProductTypes()
        {
            var types = await _productTypesRepository.GetProductTypes();

            var result = new Dictionary<Guid, string>();

            foreach(var type in types) result.Add(type.Id, type.Name);

            return result;
        }

        public async Task<Dictionary<Guid, string>> GetProperties(string propertyName)
            => await _enumValuesRepository.GetValues(propertyName);
    }
}
