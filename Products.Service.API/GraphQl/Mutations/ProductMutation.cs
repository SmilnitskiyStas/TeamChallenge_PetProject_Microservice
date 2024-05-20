using BaseLibrary.Models;
using ServerLibrary.Repositories.IRepositories;

namespace Products.Service.API.GraphQl.Mutations
{
    public class ProductMutation
    {
        private readonly IProductRepository _productRepository;

        public ProductMutation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(Guid brandId, ProductInputType productInput)
        {
            if (await _productRepository.ExistsProductAsync(productInput.Name))
            {
                throw new ArgumentNullException(nameof(productInput));
            }

            if (brandId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(brandId));
            }

            var product = ParseProduct(productInput);
            product.BrandId = brandId;

            product = await _productRepository.CreateProductAsync(product);
            return product;
        }

        public async Task<IEnumerable<Product>> CreateProductsAsync(Guid brandId, IEnumerable<ProductInputType> productInputs)
        {
            if (brandId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(brandId));
            }
            
            if (productInputs == null)
            {
                throw new ArgumentNullException(nameof(productInputs));
            }

            var products = new List<Product>();

            foreach (var productInput in productInputs)
            {
                productInput.BrandId = brandId;
                products.Add(await _productRepository.CreateProductAsync(ParseProduct(productInput)));
            }

            return products;
        }

        public async Task<Product> UpdateProductAsync(Guid productId, ProductInputType productInput)
        {
            if (productInput == null)
            {
                throw new ArgumentNullException(nameof(productInput));
            }

            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            var product = ParseProduct(productInput);
            product.ProductId = productId;
            product = await _productRepository.UpdateProductAsync(product);

            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var resutl = await _productRepository.DeleteProductAsync(productId);
            return resutl;
        }

        private static Product ParseProduct(ProductInputType productInput)
        {
            return new Product()
            {
                Name = productInput.Name,
                Description = productInput.Description ?? null,
                PickUp = productInput.PickUp ?? false,
                Delivery = productInput.Delivery ?? false,
                Price = productInput.Price,
                Create_at = productInput.Create_at ?? DateTime.Now,
                Delete_at = productInput.Delete_at ?? DateTime.MinValue,
            };
        }
    }
}
