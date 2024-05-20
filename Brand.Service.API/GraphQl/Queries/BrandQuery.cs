using BaseLibrary.Models;
using ServerLibrary.Repositories.IRepositories;

namespace Brands.Service.API.GraphQl.Queries
{
    public class BrandQuery
    {
        private readonly IBrandRepository _brandRepository;

        public BrandQuery(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();

            return brands;
        }

        public async Task<Brand> GetBrandByIdAsync(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            return brand;
        }

        public async Task<Brand> GetBrandByNameAsync(string name)
        {
            var brand = await _brandRepository.GetByNameAsync(name);

            return brand;
        }
    }
}
