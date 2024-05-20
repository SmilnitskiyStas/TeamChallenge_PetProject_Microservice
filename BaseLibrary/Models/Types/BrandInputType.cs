
namespace BaseLibrary.Models
{
    public class BrandInputType
    {
        public Guid? BrandId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Delete_at { get; set; }
        //public IEnumerable<ProductInputType>? Products { get; set; }
    }
}
