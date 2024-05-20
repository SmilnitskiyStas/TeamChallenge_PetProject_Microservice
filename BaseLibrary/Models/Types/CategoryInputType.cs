
namespace BaseLibrary.Models.Types
{
    public class CategoryInputType
    {
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Delete_at { get; set; }

        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
