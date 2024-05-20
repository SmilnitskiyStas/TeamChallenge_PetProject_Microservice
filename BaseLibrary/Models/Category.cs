
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid ParentCategoryId { get; set; }
        [Required]
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set; }

        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
