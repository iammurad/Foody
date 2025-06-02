using System;
using System.ComponentModel.DataAnnotations;

namespace Foody.EntityLayer.Concrete
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }

        // Foreign key
        public int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }
    }
}
