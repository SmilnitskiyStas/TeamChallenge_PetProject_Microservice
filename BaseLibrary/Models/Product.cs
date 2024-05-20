
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool PickUp { get; set; }
        [Required]
        public bool Delivery { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<ProductPicture> ProductPictures { get; set; }
    }
}
