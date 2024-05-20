using BaseLibrary.Models;
using Brands.Service.API.GraphQl.Subscriptions;
using HotChocolate.Subscriptions;
using ServerLibrary.Repositories.IRepositories;

namespace Brands.Service.API.GraphQl.Mutations
{
    public class BrandMutation
    {
        private readonly IBrandRepository _brandRepository;

        public BrandMutation(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> CreateBrandAsync(BrandInputType brandInput, [Service] ITopicEventSender topicEventSender)
        {
            Brand brand = new Brand()
            {
                Name = brandInput.Name,
                Description = brandInput.Description,
                Create_at = brandInput.Create_at ?? DateTime.Now,
                Delete_at = brandInput.Delete_at ?? DateTime.MinValue
            };

            brand = await _brandRepository.CreateBrandAsync(brand);

            await topicEventSender.SendAsync(nameof(BrandSubscription.BrandCreated), brand);

            return brand;
        }

        public async Task<Brand> UpdateBrandAsync(Guid brandId, BrandInputType brandInput, [Service] ITopicEventSender topicEventSender)
        {
            if (_brandRepository.GetByIdAsync(brandId) == null)
            {
                return new Brand();
            }

            Brand brand = new Brand()
            {
                BrandId = brandId,
                Name = brandInput.Name,
                Description = brandInput.Description ?? null,
                Create_at = brandInput.Create_at ?? DateTime.Now,
                Delete_at = brandInput.Delete_at ?? DateTime.MinValue,
            };

            brand = await _brandRepository.UpdateBrandAsync(brand);

            await topicEventSender.SendAsync(nameof(BrandSubscription.BrandUpdated), brand);

            return brand;
        }

        public async Task<bool> DeleteBrandAsync(Guid id)
        {
            var result = await _brandRepository.DeleteBrandAsync(id);

            return result;
        }

        private List<Product> ParseProduct(List<ProductInputType> input)
        {
            var products = new List<Product>();

            foreach (var inputItem in input)
            {
                products.Add(new Product()
                {
                    Name = inputItem.Name,
                    Description = inputItem.Description ?? null,
                    PickUp = inputItem.PickUp ?? false,
                    Delivery = inputItem.Delivery ?? false,
                    Create_at = inputItem.Create_at ?? DateTime.Now,
                    Delete_at = inputItem.Delete_at ?? DateTime.MinValue
                });
            }

            return products;
        }
    }
}
