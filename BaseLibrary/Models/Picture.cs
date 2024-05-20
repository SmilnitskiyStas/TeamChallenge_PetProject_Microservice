
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class Picture
    {
        [Key]
        public Guid PictureId { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public DateTime Create_at { get; set; }
        public DateTime Delete_at { get; set; }

        public IEnumerable<ProductPicture> ProductPictures { get; set; }
    }
}
