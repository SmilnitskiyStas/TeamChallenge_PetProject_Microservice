using BaseLibrary.Models;
using ServerLibrary.Repositories.IRepositories;

namespace Products.Service.API.GraphQl.Queries
{
    public class ProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByBrandIdAsync(Guid id)
        {
            return await _productRepository.GetProductsByBrandIdAsync(id);
        }


    }
}
