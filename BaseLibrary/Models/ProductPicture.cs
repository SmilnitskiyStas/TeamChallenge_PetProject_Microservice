
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Models
{
    public class ProductPicture
    {
        [Key]
        public Guid ProductPictureId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid PictureId { get; set; }

        public Product Product { get; set; }
        public Picture Picture { get; set; }
    }
}
