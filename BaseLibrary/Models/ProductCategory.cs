
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class ProductCategory
    {
        [Key]
        public Guid ProductCategoryId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
