
namespace BaseLibrary.Models
{
    public class ProductInputType
    {
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? PickUp { get; set; }
        public bool? Delivery { get; set; }
        public double Price { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Delete_at { get; set; }

        public Guid? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public IEnumerable<ProductCategory>? ProductCategories { get; set; }
        public IEnumerable<ProductPicture>? ProductPictures { get; set; }
    }
}
