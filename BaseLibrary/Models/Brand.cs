using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Brand
    {
        [Key]
        public Guid BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set;}

        public IEnumerable<Product>? Products { get; set; }
    }
}
