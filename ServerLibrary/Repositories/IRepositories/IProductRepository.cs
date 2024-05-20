
using BaseLibrary.Models;

namespace ServerLibrary.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> GetProductByNameAsync(string name);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsByBrandIdAsync(Guid brandId);
        Task<bool> ExistsProductAsync(Guid id);
        Task<bool> ExistsProductAsync(string name);
    }
}
