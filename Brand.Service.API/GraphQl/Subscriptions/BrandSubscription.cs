using BaseLibrary.Models;

namespace Brands.Service.API.GraphQl.Subscriptions
{
    public class BrandSubscription
    {
        [Subscribe]
        public Brand BrandCreated([EventMessage] Brand brand) => brand;

        [Subscribe]
        public Brand BrandUpdated([EventMessage] Brand brand) => brand;

        [Subscribe]
        public IEnumerable<Brand> GetBrands([EventMessage] IEnumerable<Brand> brands) => brands;
    }
}
